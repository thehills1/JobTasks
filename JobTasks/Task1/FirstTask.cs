using Newtonsoft.Json;
using RestSharp;
using System;

namespace JobTasks.Task1
{
    public class FirstTask
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public FirstTask()
        {
            _client = new RestClient("https://swapi.dev");
            _request = new RestRequest("api/people/1/");
        }

        public Hero Request()
        {
            var content = _client.ExecuteGet(_request).Content;

            try
            {
                return JsonConvert.DeserializeObject<Hero>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while getting hero information\n{e}");
                return null;
            }
        }
    }
}
