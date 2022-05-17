using System;
using HelloWorld;
interface IString
{
    string name { get; set; }
    int age { get; set; }
}

class MyString : IDisposable
{
    public void Dispose() { }
}

class Program
{
    static void Main(string[] args)
    {
        using User user = new User("minh", 12);

        Console.WriteLine(user.name);
        Console.Clear();

        // const int MAX_USER = 2;
        // User[] users = new User[MAX_USER];
        // users[0] = new User("Minh", 1);
        // users[1] = new User("Trinh", 10);

        // int i = 0;
        // foreach (User user in users)
        // {
        //     if (user == null) continue;
        //     Console.Write($"User: {++i}" + "\n" + $"Name: {user.name}" + "\n" + $"Age: {user.age}" + "\n");
        //     if (i != MAX_USER - 1) Console.WriteLine("---------");
        // };
    }
}
