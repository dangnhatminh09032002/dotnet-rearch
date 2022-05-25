namespace MINH.Common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method | System.AttributeTargets.Property)]
    public class MyAttrAttribute : System.Attribute
    {
        private string _msg;
        public string Author;
        public MyAttrAttribute(string msg)
        {
            _msg = msg;
            Console.WriteLine(_msg);
        }
    }
}