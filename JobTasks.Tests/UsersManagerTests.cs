using JobTasks.Task3;

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
        public void TryCreateNewUserPositiveTest(string username, string job)
        {
            var result = _usersManager.TryCreateNewUser(username, job, out var response);

            Assert.That(result, Is.True, $"Ошибка во время создания нового пользователя, [username]=[{username}], [job]=[{job}]");
            Assert.That(response, Is.Not.Null, $"Ошибка во время создания нового пользователя, [username]=[{username}], [job]=[{job}]");
            Assert.That(response.Name, Is.EqualTo(username), $"Неверное имя пользователя после его создания, [expected]=[{username}], [actual]=[{response.Name}]");
            Assert.That(response.Job, Is.EqualTo(job), $"Неверное имя должности после его создания, [expected]=[{job}], [actual]=[{response.Job}]");
        }

        [Test]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        [TestCase("a", "")]
        [TestCase("", "t")]
        public void TryCreateNewUserNegativeTest(string username, string job)
        {
            var result = _usersManager.TryCreateNewUser(username, job, out var response);

            Assert.That(result, Is.False, $"Был создан пользователь с некорректными данными, [username]=[{username}], [job]=[{job}]");
            Assert.That(response, Is.Null, $"Был создан пользователь с некорректными данными, [username]=[{username}], [job]=[{job}]");
        }
    }
}