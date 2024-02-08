using JobTasks.Task3;
using System;
using System.Data;

namespace JobTasks.Tests
{
    [TestFixture]
    public class UsersManagerTests
    {
        private UsersManager _usersManager;

        [SetUp]
        public void SetUp()
        {
            _usersManager = new UsersManager();
        }

        [Test]
        [TestCase("Mark", "Leader")]
        [TestCase("Test username 123", "Test job")]
        public void CreateNewUserPositiveTest(string username, string job)
        {
            var response = CreateNewUser(username, job);

            Assert.That(response, Is.Not.Null, $"ќшибка во врем€ создани€ нового пользовател€, [username]=[{username}], [job]=[{job}]");
            Assert.That(response.Created, Is.True, $"ќшибка во врем€ создани€ нового пользовател€, [username]=[{username}], [job]=[{job}]");
            Assert.That(response.Name, Is.EqualTo(username), $"Ќеверное им€ пользовател€ после его создани€, [expected]=[{username}], [actual]=[{response.Name}]");
            Assert.That(response.Job, Is.EqualTo(job), $"Ќеверное им€ должности после его создани€, [expected]=[{job}], [actual]=[{response.Job}]");
            Assert.That(response.Id, Is.Not.Default, $"Id пользовател€ не был назначен при успешном создании учетной записи.");
            Assert.That(response.CreatedAt, Is.Not.Default, $"¬рем€ создани€ аккаунта пользовател€ не было назначено при успешном создании учетной записи.");
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        
        [TestCase("", "t")]
        public void CreateNewUserWrongUsernameTest(string username, string job)
        {
            Assert.Throws<AggregateException>(() => CreateNewUser(username, job), "User name cannot be null or empty.");
            
        }

        [Test]
        [TestCase("a", "")]
        [TestCase("test", null)]
        public void CreateNewUserWrongJobTest(string username, string job)
        {
            Assert.Throws<AggregateException>(() => CreateNewUser(username, job), "Job role cannot be null or empty.");

        }

        private UserInfoResponse CreateNewUser(string username, string job)
        {
            return _usersManager.CreateNewUserAsync(username, job).Result;
        }
    }
}