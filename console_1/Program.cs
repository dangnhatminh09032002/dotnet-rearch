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
        static public void Info(string message)
        {
            WriteLine(message);
        }
        static void Main(string[] args)
        {
            string message = "HELLO";
            ShowMessage show = null;
            show = Info;
            show.Invoke("Show");
            Info(message);
        }
    }
}