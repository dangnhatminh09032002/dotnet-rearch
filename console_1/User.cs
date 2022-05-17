namespace HelloWorld
{
    class User : IDisposable
    {
        public string name { get; }
        public int age { get; }
        public User(string name, int age)
        {
            if (age < 0) throw new ArgumentException("Age must be greater than 0");
            this.age = age;
            this.name = name;
        }
        ~User()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("User deleted");
            Console.ResetColor();
        }

        public void Dispose()
        {
            Console.WriteLine("--- User deleted");
        }
    }
}