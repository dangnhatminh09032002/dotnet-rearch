using System;
using System.Collections.Generic;
using static System.Console;
using Account;
// using System.List
namespace Global
{
    class Program
    {
        static double FuncTest(int arg1, string arg2)
        {
            WriteLine(arg1);
            return 1;
        }
        static void Main(string[] args)
        {
            // Action and Func : delegate - gereric
            Action action_1; // ~ delegate void action_1();
            Action<string, int> action_2; // ~ delegate void action_2(string arg1, int arg2);
            Func<int, string, double> func_1; // ~ delegate double func_1(int arg1, string arg2);

            func_1 = FuncTest;
            func_1(12, "hello");
        }
    }
}