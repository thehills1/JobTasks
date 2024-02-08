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

            Assert.That(response, Is.Not.Null, $"������ �� ����� �������� ������ ������������, [username]=[{username}], [job]=[{job}]");
            Assert.That(response.Created, Is.True, $"������ �� ����� �������� ������ ������������, [username]=[{username}], [job]=[{job}]");
            Assert.That(response.Name, Is.EqualTo(username), $"�������� ��� ������������ ����� ��� ��������, [expected]=[{username}], [actual]=[{response.Name}]");
            Assert.That(response.Job, Is.EqualTo(job), $"�������� ��� ��������� ����� ��� ��������, [expected]=[{job}], [actual]=[{response.Job}]");
            Assert.That(response.Id, Is.Not.Default, $"Id ������������ �� ��� �������� ��� �������� �������� ������� ������.");
            Assert.That(response.CreatedAt, Is.Not.Default, $"����� �������� �������� ������������ �� ���� ��������� ��� �������� �������� ������� ������.");
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