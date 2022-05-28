using System.Net;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

// CLI dotnet watch run : auto run app when change file

namespace Minh.Cs36
{
    public class MyHttpServer
    {
        private HttpListener _listener;
        public MyHttpServer(string[] prefixes)
        {
            if (!HttpListener.IsSupported) throw new ArgumentException("HttpListener is not supported");

            _listener = new HttpListener();
            foreach (string prefix in prefixes) _listener.Prefixes.Add(prefix);
        }

        public async Task Start()
        {
            _listener.Start();
            Console.WriteLine("Server Started");
            Console.WriteLine("Waiting a client connect ...");
            do
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                ProcessRequest(context);
            } while (_listener.IsListening);
        }

        protected async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request; // Information about the request
            HttpListenerResponse response = context.Response;

            Console.WriteLine($"{request.HttpMethod}: {request.RawUrl} {request.QueryString}");
            // Router
            byte[] buffer = new byte[] { };
            switch (request.Url.AbsolutePath)
            {
                case "/":
                    if (true)
                    {

                        buffer = Encoding.UTF8.GetBytes("Home page");
                    }
                    break;
                case "/users":
                    switch (request.QueryString["name"])
                    {
                        case "minh":
                            if (true)
                            {
                                string json = "{\"Name\": \"Dang Nhat Minh\",\"Age\": \"13\"}";
                                buffer = Encoding.UTF8.GetBytes(json);
                            }
                            break;
                        case "trinh":
                            if (true)
                            {
                                object json = new
                                {
                                    Name = "Tran Thi Linh Chi",
                                    Age = 15
                                };
                                buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(json));
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    response.Redirect("/");
                    break;
            }


            // Config response
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            Stream outputStream = response.OutputStream;
            await outputStream.WriteAsync(buffer, 0, buffer.Length);
            outputStream.Close();
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            string[] prefixes = new string[] { "http://127.0.0.1:5000/" };
            MyHttpServer server = new MyHttpServer(prefixes);
            Task task1 = server.Start();

            task1.Wait();
        }
    }
}