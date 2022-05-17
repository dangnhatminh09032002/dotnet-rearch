using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            string address;
            double score;
            Console.WriteLine("Your name: ");
            name = Console.ReadLine();

            Console.WriteLine("Your age: ");
            age = Console.Read();

            Console.WriteLine("Name: " + name + "\n" + "Age: " + age + "\n");
        }
    }
}