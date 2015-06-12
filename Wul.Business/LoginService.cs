using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wul.MiniSDK;
using Wul.Entities;

namespace Wul.Business
{
    public class LoginService
    {
        public async Task<string> Login(string email, string password)
        {
            var wunderApi = await WunderApi.GetWunderApi(email, password);
            return wunderApi.AccesToken;

        }

        public async Task<List<ListModel>> Workspaces(string token)
        {
            WunderApi wunderApi = new WunderApi(token);
            var lists = await wunderApi.GetLists();
            return lists;
        }

        public async Task<List<TaskModel>> WorkspaceTasks(string token, string worksapce)
        {
            WunderApi wunderApi = new WunderApi(token);
            var lists = await wunderApi.GetLists();
            var tasks = await wunderApi.GetTasks(worksapce);

            return tasks;

        }

        public async Task CreateTask(string token, int workspace, string title)
        {
            WunderApi wunderApi = new WunderApi(token);
            await wunderApi.CreateTasks(workspace, title);

        }
    }
}
