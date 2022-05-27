using System.Net;
using System.Net.Http;
namespace Minh.DotnetRearch
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://postman-echo.com/post";
            Uri uri = new Uri(url);
            CookieContainer cookieContainer = new CookieContainer();

            using var handler = new SocketsHttpHandler();
            handler.AllowAutoRedirect = true; // True is default value
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            handler.UseCookies = true; // True is default
            handler.CookieContainer = cookieContainer;

            // Setup http request
            using HttpClient httpClient = new HttpClient(handler);
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = uri;
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();
            keys.Add(new KeyValuePair<string, string>("Name", "Dang Nhat Minh"));
            keys.Add(new KeyValuePair<string, string>("Age", "20"));

            httpRequestMessage.Content = new FormUrlEncodedContent(keys);

            // Send request
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            // Handle response
            cookieContainer.GetCookies(uri).ToList().ForEach(c => { Console.WriteLine($"{c.Name}: {c.Value}"); });
            string httmToString = await httpResponseMessage.Content.ReadAsStringAsync();
        }

    }
}