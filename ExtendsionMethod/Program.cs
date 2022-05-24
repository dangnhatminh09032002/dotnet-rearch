using System;
using System.Text;
namespace CS_Extensions
{
    class Program
    {
        // // Work with DriveInfo: Thong tin cua o dia
        // public static void Main(string[] args)
        // {
        //     DriveInfo drive = new DriveInfo("C");
        //     Console.WriteLine($"Drive: {drive.Name}");
        //     Console.WriteLine($"Drive type: {drive.DriveType}");
        //     Console.WriteLine($"Label: {drive.VolumeLabel}");
        //     Console.WriteLine($"Format: {drive.DriveFormat}");
        // }

        //
        public static void Main(string[] args)
        {
            // Window: c:\a\b\c
            // Max and linux: a/b/c
            // Console.WriteLine(Path.DirectorySeparatorChar);

            // string path = Path.Combine("a", "b", "c"); // tu dong noi chuoi cho phu hop OS => a/b/c or a\b\c
            // Console.WriteLine(Directory.GetCurrentDirectory()); // Get current folder path
            // ~ Path.GetFullPath("dangnhatminh.cs") // Thuoc tinh nay tu dong noi voi folder hien tai

            // Create file
            // string pathToCreate = Path.Combine(Directory.GetCurrentDirectory(), "dangnhatminh.cs");
            // string pathToCreate = Path.GetFullPath("dangnhatminh.txt");
            // FileStream file = File.Create(pathToCreate);

            // Write file
            // string str = "this file is created";
            // File.WriteAllText("dangnhatminh.txt", str);

            // FileStream
            string path = Path.GetFullPath("dangnhatminh.txt");
            using FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            // string -> bytes
            string str = "this file is created ---- ";
            byte[] buffer_str = Encoding.UTF8.GetBytes(str);

            // int, double, ... -> bytes
            int number = 12;
            byte[] buffer_num = BitConverter.GetBytes(number);

            stream.Write(buffer_str);
        }
    }
}

