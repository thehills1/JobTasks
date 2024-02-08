using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

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

        public async Task<Hero> RequestAsync()
        {
            var result = await _client.ExecuteGetAsync(_request);

            try
            {
                return JsonConvert.DeserializeObject<Hero>(result.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while getting hero information\n{e}");
                return null;
            }
        }
    }
}
