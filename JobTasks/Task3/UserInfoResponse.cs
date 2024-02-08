using Newtonsoft.Json;
using System;

namespace JobTasks.Task3
{
    public class UserInfoResponse
    {
        [JsonIgnore]
        public bool Created { get; set; }

        public string Name { get; set; }

        public string Job { get; set; }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
