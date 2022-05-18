using System;
using System.Collections.Generic;
using static System.Console;
using Account;
// using System.List
namespace Global
{
    enum USER_KEY
    {
        Name,
        Age
    };
    delegate double Sum(double x, double y);

    class Program
    {
        static void Main(string[] args)
        {
            var func_1 = (double a, double b) =>
            {
                double sum = a + b;
                return sum;
            };
            WriteLine(func_1(1, 2)); // Output 3

            Sum sum;
            sum = (double a, double b) =>
            {
                double sum = a + b;
                return sum;
            };
            WriteLine(sum?.Invoke(5, 1)); // Output 6

            Func<double, double, double> sum_1;
            sum_1 = (double a, double b) =>
            {
                double sum = a + b;
                return sum;
            };
            WriteLine(sum_1?.Invoke(4, 3)); // Output 7

            Dictionary<USER_KEY, string>[] users = {
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Minh" }, { USER_KEY.Age, "12" } },
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Hung" }, { USER_KEY.Age, "12" } },
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Son" }, { USER_KEY.Age, "12" } },
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Chi" }, { USER_KEY.Age, "12" } },
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Trinh" }, { USER_KEY.Age, "12" } },
                                                    new Dictionary<USER_KEY, string>() { { USER_KEY.Name, "Tram" }, { USER_KEY.Age, "12" } },
                                                };
            foreach (Dictionary<USER_KEY, string> user in users)
            {
                WriteLine("-----------");
                user.ToList().ForEach((KeyValuePair<USER_KEY, string> detail) =>
                {
                    WriteLine($"{detail.Key}: {detail.Value}");
                });
            };

            // KeyValuePair<USER_KEY, string>[] users = {
            //  new KeyValuePair<USER_KEY, string>(USER_KEY.Name, "minh"),
            //  new KeyValuePair<USER_KEY, string>(USER_KEY.Name, "trinh"),
            //  new KeyValuePair<USER_KEY, string>(USER_KEY.Name, "chi")
            // };
            // foreach (KeyValuePair<USER_KEY, string> user in users) { WriteLine($"{user.Key}: {user.Value}"); };
            // users.ToList().ForEach((KeyValuePair<USER_KEY, string> user) =>
            //                 {
            //                     WriteLine($"{user.Key}: {user.Value}");
            //                 });
        }
    }
}