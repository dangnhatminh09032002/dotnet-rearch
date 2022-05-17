using System;
using System.Collections.Generic;
using static System.Console;
using Account;
// using System.List
namespace Global
{
    delegate void ShowMessage(string message);

    class Program
    {
        static public void InfoSuccess(string message)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(message);
            ResetColor();
        }

        static public void InfoWarning(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ResetColor();
        }
        static void Main(string[] args)
        {
            string message = "HELLO";
            ShowMessage show;
            show = InfoSuccess;
            show += InfoWarning;
            show += InfoWarning;
            show += InfoSuccess;
            show?.Invoke(message);
        }
    }
}