using System;
using System.Text;
using System.Linq;

namespace CS_Extensions
{
    class Program
    {
        class Persion
        {
            private static int _createdCount = 0;
            private static List<Dictionary<string, dynamic>> _store = new List<Dictionary<string, dynamic>>();
            private int _id = _createdCount++;
            private string _name = "";
            private int _age = 0;
            public int Id => _id;
            public string Name
            {
                set { _name = value; SaveToStore(); }
                get => _name;
            }
            public int Age
            {
                set { _age = value; SaveToStore(); }
                get => _age;
            }
            public Persion(string name, int age)
            {
                _name = name;
                _age = age;
                SaveToStore();
            }


            public void SaveToStore()
            {
                Dictionary<string, dynamic> newPersion = new Dictionary<string, dynamic>();
                newPersion.Add("id", _id);
                newPersion.Add("name", _name);
                newPersion.Add("age", _age);
                try
                {
                    _store[_id] = newPersion;
                }
                catch (Exception e) { _store.Add(newPersion); };
            }

            public static void SaveToFile(FileStream stream)
            {
                try
                {
                    stream.Write(Encoding.UTF8.GetBytes(""));
                    string str = "";
                    str += $"Count: {_createdCount}\n";
                    foreach (var items in _store)
                    {
                        str += "---------------\n";
                        foreach (KeyValuePair<string, dynamic> kvp in items)
                        {
                            str += $"{kvp.Key} - {kvp.Value}\n";
                        }
                    };
                    stream.Write(Encoding.UTF8.GetBytes(str));
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Write file faild");
                    Console.ResetColor();
                }

            }

            public static void PrintStore()
            {
                foreach (var items in _store)
                {
                    Console.WriteLine($"-------------");
                    foreach (KeyValuePair<string, dynamic> kvp in items)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                };
            }
        }

        public static void Main(string[] args)
        {
            Persion minh = new Persion("minh", 12);
            Persion tring = new Persion("tring", 12);
            Persion chi = new Persion("chi", 21);
            string path = Path.GetFullPath("store.txt");
            using FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            Persion.SaveToFile(stream);
            chi.Name = "This is chi";
            Persion.SaveToFile(stream);
        }
    }
}

