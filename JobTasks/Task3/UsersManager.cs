using JobTasks.Task2;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

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

        public async Task<UserInfoResponse> CreateNewUserAsync(string username, string job)
        {
            var defaultResponse = new UserInfoResponse() { Created = false, Name = username, Job = job };
            UserInfoResponse response = null;

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("User name cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(job))
            {
                throw new ArgumentException("Job role cannot be null or empty.", nameof(job));
            }

            var userInfo = new UserInfo(username, job);
            var rawResponse = await _client.ExecutePostAsync<UserInfoResponse>(_request.AddBody(userInfo));
            if (rawResponse.Data == null || rawResponse.StatusCode != HttpStatusCode.Created)
            {
                return defaultResponse;
            }

            response = rawResponse.Data;
            response.Created = response.CreatedAt != default;

            return response;
        }
    }
}
