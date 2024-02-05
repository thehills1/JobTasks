using Newtonsoft.Json;
using RestSharp;
using System;

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

        public UsersInfo Request()
        {
            var content = _client.ExecuteGet(_request).Content;

            try
            {
                return JsonConvert.DeserializeObject<UsersInfo>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while getting users info\n{e}");
                return null;
            }
        }
    }
}
