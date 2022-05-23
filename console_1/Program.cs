using System;
class Program
{
    /* 
        publisher -> class - phat su kien
        subsriber -> class - nhan su kien
    */

    public delegate void InputNumberEvent(int x);
    // Publisher
    class UserInput
    {
        public InputNumberEvent inputNumberEvent { set; get; }
        public void Input()
        {
            do
            {
                Console.Write("Input Number: ");
                string s = Console.ReadLine();
                try
                {
                    int i = Int32.Parse(s);
                    inputNumberEvent?.Invoke(i);
                }
                catch (Exception ex) { }
            } while (true);
        }
    }

    class MyEvent
    {
        public void Square(int x)
        {
            Console.WriteLine("Square: " + x * x);
        }

        public void SubEvent(UserInput input, InputNumberEvent callback)
        {
            input.inputNumberEvent = callback;
        }
    }
    public static void Main(string[] args)
    {
        UserInput userInput = new UserInput();

        MyEvent myEvent = new MyEvent();
        myEvent.SubEvent(userInput, void (int x) =>
        {
            Console.WriteLine("Matchin");
        });

        userInput.Input();
    }
}