using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

// MultipartFormDataContent

public class WhiteList
{
    public static readonly string[] Host = new string[] { "google.com", "facebook.com", "twitter.com" };
}

namespace Minh.DotnetRearch
{
    public class Program
    {
        public class MyHttpClientHandler : HttpClientHandler
        {
            public MyHttpClientHandler(CookieContainer cookieContainer)
            {
                CookieContainer = cookieContainer;
                AllowAutoRedirect = true;
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                UseCookies = true;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                try
                {
                    Console.WriteLine("Connecting to {0}", request.RequestUri.ToString());
                    HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
                    Console.WriteLine("Connection ended");
                    return response;
                }
                catch (ArgumentNullException ex) { throw new ArgumentNullException(ex.Message); }
            }
        }

        public class ChangeUriIfNotMatch : DelegatingHandler
        {
            public ChangeUriIfNotMatch(HttpMessageHandler innerHandler) : base(innerHandler) { }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                try
                {
                    string host = request.RequestUri.Host.ToLower();
                    Console.WriteLine("Checking {0} exists white ?", host);
                    bool exists = Array.Exists(WhiteList.Host, e => e.ToLower()
                    .Contains(host));
                    string requestTo = "https://github.com"; //request to if dont exit in white list
                    if (!exists) request.RequestUri = new Uri(requestTo);
                    Console.WriteLine("Checked");

                    return base.SendAsync(request, cancellationToken);
                }
                catch (ArgumentNullException ex) { throw new ArgumentNullException(ex.Message); }
            }
        }

        public class AddFormDataRequest : DelegatingHandler
        {
            public AddFormDataRequest(HttpMessageHandler innerHandler) : base(innerHandler) { }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                bool endQuery = true; // Nếu true thì không gửi req lên nữa mà trả thẳng response(tự tạo) về luôn

                // Create form data
                Console.WriteLine("Creating form data");
                List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>() { };
                formData.Add(new KeyValuePair<string, string>("Name", "Dang Nhat Minh"));
                formData.Add(new KeyValuePair<string, string>("Age", "21"));

                // Setup http content
                request.Content = new FormUrlEncodedContent(formData);


                // Created
                Console.WriteLine("Form data created: ");

                if (endQuery)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes($"K gui req len server {request.RequestUri.Host}"));
                    return await Task.FromResult<HttpResponseMessage>(response);
                }

                // Inject query for base
                return await base.SendAsync(request, cancellationToken);
            }
        }

        static async Task Main(string[] args)
        {
            string url = "https://github.com";
            CookieContainer cookies = new CookieContainer();

            // Req -> FirstHandler -> SecondHandler -> ThirdHandler -> Res -> ThirdHandler -> SecondHandler -> FirstHandler -> MyServer;
            MyHttpClientHandler thirdHandler = new MyHttpClientHandler(cookies);
            ChangeUriIfNotMatch secondHandler = new ChangeUriIfNotMatch(thirdHandler);
            AddFormDataRequest firstHandler = new AddFormDataRequest(secondHandler);

            using HttpClient httpClient = new HttpClient(firstHandler);
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            await httpClient.SendAsync(httpRequestMessage);

            // // Section HttpMessageHandler and CookieContainer
            // return;
            // string url = "https://postman-echo.com/post";
            // Uri uri = new Uri(url);
            // CookieContainer cookieContainer = new CookieContainer();

            // using var handler = new SocketsHttpHandler();
            // handler.AllowAutoRedirect = true; // True is default value
            // handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            // handler.UseCookies = true; // True is default
            // handler.CookieContainer = cookieContainer;

            // // Setup http request
            // using HttpClient httpClient = new HttpClient(handler);
            // using HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            // httpRequestMessage.Method = HttpMethod.Post;
            // httpRequestMessage.RequestUri = uri;
            // httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            // List<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>();
            // keys.Add(new KeyValuePair<string, string>("Name", "Dang Nhat Minh"));
            // keys.Add(new KeyValuePair<string, string>("Age", "20"));

            // httpRequestMessage.Content = new FormUrlEncodedContent(keys);

            // // Send request
            // HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            // // Handle response
            // cookieContainer.GetCookies(uri).ToList().ForEach(c => { Console.WriteLine($"{c.Name}: {c.Value}"); });
            // string httmToString = await httpResponseMessage.Content.ReadAsStringAsync();
        }

    }
}