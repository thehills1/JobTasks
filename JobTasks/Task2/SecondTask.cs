using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace JobTasks.Task2
{
    public class SecondTask
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public SecondTask()
        {
            _client = new RestClient("https://reqres.in");
            _request = new RestRequest("api/users?page=2");
        }

        public async Task<UsersInfo> RequestAsync()
        {
            var result = await _client.ExecuteGetAsync(_request);

            try
            {
                return JsonConvert.DeserializeObject<UsersInfo>(result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while getting users info\n{e}");
                return null;
            }
        }
    }
}
