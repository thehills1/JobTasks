using System;
using System.Linq;
using JobTasks.Task1;
using JobTasks.Task2;
using JobTasks.Task3;
using Newtonsoft.Json;

namespace JobTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================ TASK 1 ================");
            var task1 = new FirstTask();
            var hero = task1.Request();
            Console.WriteLine(string.Join("\n", hero.Films));
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("================ TASK 2 ================");
            var task2 = new SecondTask();
            var usersInfo = task2.Request();
            Console.WriteLine(usersInfo.Data.First(user => user.FirstName == "George" && user.LastName == "Edwards").Email);
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("================ TASK 3 ================");
            var task3 = new UsersManager();
            task3.TryCreateNewUser("testusername", "testrole", out var response);
            Console.WriteLine("========================================");
        }
    }
}
