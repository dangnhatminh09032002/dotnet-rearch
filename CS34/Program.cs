// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient httpClient = new HttpClient();


        // string data = @"{
        //     ""name"": ""dang nhat minh"",
        //     ""age"": ""20""
        // }";

        //FormUrlEncodedContent content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("name", "dang nhat minh") });
        // StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        MultipartFormDataContent content = new MultipartFormDataContent();
        content.Add();
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Content = content;
        httpRequestMessage.Method = HttpMethod.Post;
        // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        //httpRequestMessage.Content = new StringContent(Newtonsoft.Json.JsonSerializer(new {}), Encoding.UTF8, "application/json");
        httpRequestMessage.RequestUri = new Uri("https://www.google.com");
        httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        string html = await httpResponseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(httpRequestMessage.Headers.ToString());
    }
}