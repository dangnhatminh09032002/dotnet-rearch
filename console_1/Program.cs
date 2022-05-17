using System;
using System.Collections.Generic;
using static System.Console;
using Account;
// using System.List

class Program
{
    static void Main(string[] args)
    {
        // Anonymous types
        List<User> listUsers = new List<User>() {
            new User(){Name = "John", Age = 12},
            new User(){Name = "Trinh", Age = 13},
            new User(){Name = "Chi", Age = 14},
            new User(){Name = "Tram", Age = 15},

        };

        var usersSelected = from user in listUsers
                            where user.Age >= 12
                            select user;

        foreach (var user in usersSelected)
        {
            WriteLine(user.Name, user.Age);

        }

        // Dynamic types
        dynamic obj = new Object();
        obj.usres = listUsers;
        obj = "";
    }
}
