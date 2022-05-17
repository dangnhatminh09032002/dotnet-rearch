namespace NS_A
{
    static class SayHello
    {
        partial class Employee
        {
            public string Name { get; set; }
            public Employee() { }
        }


        public static void sayHello()
        {
            Console.WriteLine("Hello");
        }
    }
    class User
    {
        public string name { get; set; }
        public int age { get; set; }
        public User(string name = "", int age = 0)
        {
            if (age < 0) throw new ArgumentException("Age must be greater than 0");
            this.age = age;
            this.name = name;
        }
    }

    class Account : User
    {
        public Account(string name = "", int age = 0) : base(name, age)
        {

        }
    }
}