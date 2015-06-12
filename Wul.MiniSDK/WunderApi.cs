using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Newtonsoft.Json;
using Wul.Entities;

namespace Wul.MiniSDK
{
    public class WunderApi
    {
        public string AccesToken { get; set; }
       

        public static async Task<WunderApi> GetWunderApi(string email, string password)
        {
            WunderApi wunderApi = new WunderApi();

            await wunderApi.Login(email, password);
            return wunderApi;
        }


        public WunderApi()
        {
        }

        public WunderApi(string accessToken)
        {
            AccesToken = accessToken;
        }
        
        private async Task Login(string email, string password)
        {
            using (var client = CreateClient())
            {
                var credentials = JsonConvert.SerializeObject(new { email, password });
                var content = new StringContent(credentials, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://a.wunderlist.com/api/v1/user/authenticate", content);

                var json = await response.Content.ReadAsStringAsync();
                dynamic o = JsonConvert.DeserializeObject(json);

                AccesToken = (string)o.access_token;
            }
        }

        public async Task CreateTasks(int list_id, string title)
        {
            using (var client = CreateClient(AccesToken))
            {
                var task = JsonConvert.SerializeObject(new { list_id, title });
               var content = new StringContent(task, Encoding.UTF8, "application/json");

                var uri = "http://a.wunderlist.com/api/v1/tasks";
                var response = await client.PostAsync(uri, content);

                var json = await response.Content.ReadAsStringAsync();
                
            }
        }

        public async Task<List<ListModel>> GetLists()
        {
            using (var client = CreateClient(AccesToken))
            {
                var response = await client.GetAsync("http://a.wunderlist.com/api/v1/lists");

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ListModel>>(json);
            }
        }

        public async Task<List<TaskModel>> GetTasks(string id)
        {
            using (var client = CreateClient(AccesToken))
            {
                var response = await client.GetAsync("http://a.wunderlist.com/api/v1/tasks?list_id=" + id);

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TaskModel>>(json);
            }
        }

        private HttpClient CreateClient(string accessToken)
        {
            var client = CreateClient();
            client.DefaultRequestHeaders.Add("X-Access-Token", accessToken);
            return client;
        }

        private static HttpClient CreateClient()
        {
            var client = new HttpClient();
            var clientId = CloudConfigurationManager.GetSetting("X-Client-ID");
            client.DefaultRequestHeaders.Add("X-Client-ID", clientId);
            return client;
        }
    }
}
