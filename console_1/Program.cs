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
        public event InputNumberEvent inputNumberEvent; // Phuong thuc nay khong the bi gan lai chi co the them sua xoa
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

        public void SubEvent(InputNumberEvent callback)
        {
            inputNumberEvent += callback;
        }
    }

    class MyEvent
    {
        public static void SubEvent(UserInput input, InputNumberEvent callback)
        {
            input.inputNumberEvent += callback;
        }
    }
    public static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        userInput.SubEvent(void (int x) => Console.WriteLine($"Binh phuong cua {x} la: " + x * x));
        userInput.SubEvent(void (int x) => Console.WriteLine($"Gap doi cua {x} la: " + x * x));

        // MyEvent.SubEvent(userInput, void (int x) => Console.WriteLine($"Binh phuong cua {x} la: " + x * x));
        // MyEvent.SubEvent(userInput, void (int x) => Console.WriteLine($"Gap doi cua {x} la: " + x * x));

        userInput.Input();
    }
}