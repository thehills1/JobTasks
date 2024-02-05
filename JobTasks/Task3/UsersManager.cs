using JobTasks.Task2;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace JobTasks.Task3
{
    public class UsersManager
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public UsersManager() 
        {
            _client = new RestClient("https://reqres.in");
            _request = new RestRequest("api/users", Method.Post);
        }

        public bool TryCreateNewUser(string username, string job, out UserInfoResponse response)
        {
            response = null;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(job)) return false; 

            var userInfo = new UserInfo(username, job);
            var rawResponse = _client.ExecutePost(_request.AddBody(userInfo));
            if (rawResponse.StatusCode != HttpStatusCode.Created) return false;

            try
            {
                response = JsonConvert.DeserializeObject<UserInfoResponse>(rawResponse.Content);
                return response != null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while creating new user\n{e}");
                return false;
            }
        }
    }
}
