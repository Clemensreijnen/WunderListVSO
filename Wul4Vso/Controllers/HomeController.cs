using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Wul.Business;
using MVCTEST.Models;
using System.Web.SessionState;

using Wul.Entities;

namespace MVCTEST.Controllers
{
    [SessionState(SessionStateBehavior.Required)]
    public class HomeController : Controller
    {

        public ActionResult Main()
        {
            return View();

        }
        public async Task<ActionResult> Index()
        {
            Account model = new Account();

            SelectList list = null;
            var token = Session["token"] as string;

            if (token == null)
            {
                list = new SelectList(Workspace.Current.Lists, "Id", "Title");
                ViewBag.Workspaces = list;
                return View(model);
            }
            
            model.Token = token;
            var ws = await new LoginService().Workspaces(token);
            list = new SelectList(ws, "Id", "Title");
            ViewBag.Workspaces = list;
            
            return View(model);
        }

        [HttpPost]
        public  async Task<ActionResult> Index(Account model)
        {
            try
            {
                var token = Session["token"] as string;
                if (token == null)
                {
                    string email = model.email;
                    string password = model.Password;
                    string wordspace = model.Workspace;

                    token = await new LoginService().Login(email, password);
                    Session["token"] = token;
                    model.Token = token;

                    var ws = await new LoginService().Workspaces(token);
                    var list = new SelectList(ws, "Id", "Title");
                    ViewBag.Workspaces = list;
                }
                return View(model);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

 
        public async Task<string> Tasks(string workspaceid)
        {
            var WorkSpaceTasks = new WorkSpaceTasks();

            Session["workspace"] = workspaceid;

            var token = Session["token"] as string;
            var ws = await new LoginService().WorkspaceTasks(token, workspaceid);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='table .ms-table table-hover'>");
            sb.Append("<thead>");
            sb.Append("<tr class='.ms-tableRow'>    ");
            sb.Append("<th class='.ms-tableCell'>Name</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            foreach (var item in ws)
            {
                sb.Append("<tr class='.ms-tableRow' id=" + item.Title + ">");
                sb.Append("<td class='.ms-tableCell'>");
                sb.Append(item.Title);
                sb.Append("</td></tr>");
            }
            sb.Append(" </tbody></table>");
            return (sb.ToString());

        }

        public async Task AddToWunderlist(string workItemTitle)
        {
            var token = Session["token"] as string;
            var workspace = Session["workspace"] as string;
            if(token != "" && workspace != "")
            {
                var wsId = int.Parse(workspace);
                await new LoginService().CreateTask(token, wsId, workItemTitle);
            }
        }
    }
}