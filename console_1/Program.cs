using System;
class Program
{
    /* 
        publisher -> class - phat su kien
        subsriber -> class - nhan su kien
    */
    class DataInputs : EventArgs
    {
        public int Data { set; get; }
        public DataInputs(int x)
        {
            Data = x;
        }
    }
    public delegate void InputNumberEvent(int x);
    // Publisher
    class UserInput
    {
        // public event InputNumberEvent inputNumberEvent; // Phuong thuc nay khong the bi gan lai chi co the them sua xoa

        public event EventHandler inputNumberEvent; // ~ Deleget void KIEU(object? sender, EventArgs args)

        public void Input()
        {
            do
            {
                Console.Write("Input Number: ");
                string s = Console.ReadLine();
                try
                {
                    int i = Int32.Parse(s);
                    inputNumberEvent?.Invoke(this, new DataInputs(i));
                }
                catch (Exception ex) { }
            } while (true);
        }

        public void SubEvent(EventHandler callback)
        {
            inputNumberEvent += callback;
        }
    }

    // class MyEvent
    // {
    //     public static void SubEvent(UserInput input, InputNumberEvent callback)
    //     {
    //         input.inputNumberEvent += callback;
    //     }
    // }
    public static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        userInput.SubEvent(void (object? sender, EventArgs e) =>
        {
            DataInputs data = (DataInputs)e;
            Console.WriteLine($"Binh phuong cua {data.Data} la: " + data.Data * data.Data);
        });

        // MyEvent.SubEvent(userInput, void (int x) => Console.WriteLine($"Binh phuong cua {x} la: " + x * x));
        // MyEvent.SubEvent(userInput, void (int x) => Console.WriteLine($"Gap doi cua {x} la: " + x * x));

        userInput.Input();
    }
}