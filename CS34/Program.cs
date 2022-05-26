// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string host = "www.facebook.com";
        string url = $"https://{host}";

        byte[] buffer = await DownloadPageDataBytes(url);

        Task task_3 = SaveFileInHereWithBytes(buffer, "facebook.html");
        DownloadStream(url, "facebook.html");

        Console.ReadKey();
    }


    static async Task<string> GetWebContent(string url)
    {
        try
        {
            using HttpClient httpClient = new HttpClient();

            // Add headers before request
            httpClient.DefaultRequestHeaders.Add("content-type", "application/json");

            // Send request
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            //ShowHeader(httpResponseMessage.Headers);
            return await httpResponseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Page not found");
            Console.ResetColor();
            return "";
        }
    }
    static async Task<byte[]> DownloadPageDataBytes(string url)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

        byte[] buffer = new byte[] { };
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            byte[] bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
        }
        catch (Exception ex) { }
        return buffer;
    }
    static async Task DownloadStream(string url, string fileName)
    {
        HttpClient httpClient = new HttpClient();
        string path = Path.GetFullPath(fileName); // Path to the file
        try
        {
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            using Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();

            using FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            // Doan code ben duoi se save file theo tung EVERY_SIZE cho den khi full
            const int EVERY_SIZE = 1000; // save other 1000 byte
            int current = 0;
            int previous = 0;
            do
            {
                previous = current;
                current += EVERY_SIZE;
                byte[] buffer = new byte[EVERY_SIZE];
                int sizeByteCurrent = await stream.ReadAsync(buffer, previous, current); // 0 neu k con gi de doc
                fsWrite.Write(buffer, previous, current);
                if (sizeByteCurrent == 0) break;
            } while (true);
        }
        catch (Exception ex) { }
    }
    static async Task SaveByEachSize(int size, byte[] buffer, string fileName)
    {
        string path = Path.GetFullPath(fileName);
        using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        fs.Write(buffer, 0, buffer.Length);
    }
    static async Task SaveFileInHereWithBytes(byte[] buffer, string fileName)
    {
        // Save data to file
        string path = Path.GetFullPath(fileName);
        using FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        fs.Write(buffer, 0, buffer.Length);
    }
    static void ShowHeader(HttpResponseHeaders headers)
    {
        Console.WriteLine($"-- Headers --");
        foreach (var header in headers)
        {
            Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }

}

// var ping = new Ping();
// var response = ping.Send(host);

// if (response.Status == IPStatus.Success)
// {
//     Uri uri = new Uri(url);
//     PropertyInfo[] properties = uri.GetType().GetProperties();
//     foreach (PropertyInfo property in properties)
//     {
//         Console.WriteLine($"{property.Name}: {property.GetValue(uri)}");
//     }
// }
// Task<string> task = GetWebContent(url);
// task.Wait();