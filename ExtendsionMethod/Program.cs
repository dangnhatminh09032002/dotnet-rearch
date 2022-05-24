using System;
using System.Text;
using System.Linq;
using System.IO;

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

            public static void SaveToFile(Stream stream)
            {
                try
                {
                    stream.Write(Encoding.UTF8.GetBytes(""), 0, 0);
                    string str = new string("");
                    str += "______________[ History ]______________\n";
                    str += $"| Count: {_createdCount}\n";
                    str += $"| Date: {DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")}\n";

                    str += $"|\n";
                    str += $"| -- LIST PERSION CREATED --\n";
                    int i = 0;
                    foreach (var items in _store)
                    {
                        if (i != 0) str += "| ---------------\n";
                        foreach (KeyValuePair<string, dynamic> kvp in items)
                        {
                            str += $"| {kvp.Key}: {kvp.Value}\n";
                        }
                        i++;
                    };
                    str += "|______________________________________\n";

                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    stream.Write(buffer);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Write file faild");
                    Console.ResetColor();
                }

            }

            public static void LoadFile(Stream stream)

            {
                byte[] bufferID = new byte[128];
                stream.Read(bufferID, 0, 128);
                Console.WriteLine("id : " + BitConverter.ToString(bufferID));
                Console.WriteLine("id : " + stream.Read(bufferID, 0, 128));
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
            string path = Path.GetFullPath("store.dat");
            using FileStream stream = new FileStream(path, FileMode.OpenOrCreate); // => use "using"
            Persion.SaveToFile(stream);
            chi.Name = "Linh Chi";
            Persion.SaveToFile(stream);
            Persion.LoadFile(stream);
        }
    }
}

