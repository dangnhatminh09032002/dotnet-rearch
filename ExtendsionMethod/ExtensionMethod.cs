namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static void Print(this string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
