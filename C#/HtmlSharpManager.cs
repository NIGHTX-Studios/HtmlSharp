using NIGHTX.HtmlSharp.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIGHTX.HtmlSharp
{
    public static class HtmlSharpManager
    {
        static Dictionary<string, EventHandler<WebClientEA>> callbacks = new();

        public static void StartHtmlSharp(string htmlLocation, int port = 80)
        {
            MyHttpServer mhs = new MyHttpServer(port);
            mhs.HtmlLocation = htmlLocation;
            mhs.callbacks = callbacks;
            mhs.listen();
        }

        public static void RegisterCallback(string callbackName, EventHandler<WebClientEA> callbackHandler)
        {
            callbacks.Add(callbackName, callbackHandler);
        }

        public class WebClientEA : EventArgs
        {
            public WebClient WebClient;
            public List<string> Arguments;
        }

        class MyHttpServer : HttpServer
        {
            public Dictionary<string, EventHandler<WebClientEA>> callbacks = new();
            public string HtmlLocation = "./";

            public MyHttpServer(int port)
                : base(port)
            {
            }

            string ParsedHtmlLocation
            {
                get
                {
                    return HtmlLocation.Replace("./", AppDomain.CurrentDomain.BaseDirectory) + "\\";
                }
            }

            string ParseHttpUrl(string url)
            {
                if(url == "/")
                {
                    return "index.html";
                }else
                {
                    return url.Substring(1);
                }
            }

            public override void handleGETRequest(HttpProcessor p)
            {
                Console.WriteLine("GET:" + p.http_url);
                if(p.http_url == "/alert")
                {
                    Console.WriteLine("alert");
                    WebClient.Create(p).Alert("https://google.com");
                    return;
                }

                p.outputStream.WriteLine(File.ReadAllText(ParsedHtmlLocation + ParseHttpUrl(p.http_url)));
            }

            public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
            {
                foreach (DictionaryEntry item in p.httpHeaders)
                {
                    if(item.Key.ToString() == "Callback")
                    {
                        foreach (KeyValuePair<string, EventHandler<WebClientEA>> kvp in callbacks)
                        {
                            if(kvp.Key.ToString().Split(";")[0] == item.Value.ToString().Split(";")[0])
                            {
                                List<string> args = new List<string>();
                                args.AddRange(item.Value.ToString().Split(";"));
                                args.RemoveAt(0);
                                kvp.Value.Invoke(typeof(HtmlSharpManager), new WebClientEA()
                                {
                                    WebClient = WebClient.Create(p),
                                    Arguments = args
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}
