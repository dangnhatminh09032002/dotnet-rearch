using static System.Console;
using NS_A;
class Program
{
    static void Main(string[] args)
    {
        Account acc_1 = new Account("minh", 12);

        const int MAX_USER = 2;
        User[] users = new User[MAX_USER];
        users[0] = new User("Minh", 1);
        users[1] = new User("Trinh", 10);

        int i = 0;
        foreach (User user in users)
        {
            if (user == null) continue;
            Console.Write($"User: {++i}" + "\n" + $"Name: {user.name}" + "\n" + $"Age: {user.age}" + "\n");
            if (i != MAX_USER - 1) Console.WriteLine("---------");
        };
    }
}
