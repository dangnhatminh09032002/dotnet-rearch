using ExtensionMethods;
using System.Linq;

namespace CS_Extensions
{
    class Number
    {
        private object _value;
        public decimal Value => decimal.Parse(_value.ToString());

        public Number(object value)
        {
            bool isNumber = value.ToString().All(char.IsDigit);
            if (isNumber)
            {
                _value = value;
            }
            else
            {
                throw new ArgumentException("Argument is not a number");
            }
        }

        // Operatores
        public static decimal operator +(Number a, Number b)
        {
            return a.Value + b.Value;
        }

        // Indexer
        public dynamic this[string str]
        {
            get
            {
                switch (str)
                {
                    case "Value":
                        return _value;
                    default:
                        throw new ArgumentException($"Argument [{str}] does not exist");
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Number num_1 = new Number("12");
            Number num_2 = new Number("15");
            Console.WriteLine(num_2["Values"]);
            decimal num_3 = num_1 + num_2;
            Console.WriteLine("Number: " + num_3.ToString());
        }
    }
}

