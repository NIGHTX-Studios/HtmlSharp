using NIGHTX.HtmlSharp.Networking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIGHTX.HtmlSharp
{
    public class WebClient
    {
        HttpProcessor p;

        public static WebClient Create(HttpProcessor p)
        {
            WebClient w = new();
            w.p = p;
            return w;
        }

        public void Redirect(string newUrl)
        {
            p.outputStream.WriteLine("REDIR:" + newUrl.Replace(":", "DP_"));
        }

        public void WriteSuccess()
        {
            p.writeSuccess();
        }

        public void WriteFailure()
        {
            p.writeFailure();
        }

        public void Alert(string text)
        {
            p.outputStream.WriteLine("ALERT:" + text);
        }

        public void Popup(Link link, string title, int width, int height)
        {
            p.outputStream.WriteLine("POPUP:" + link.UsableURL + ":" + title + ":width=%W%,height=%H%".Replace("%W%", "" + width).Replace("%H%", "" + height));
        }

        public void SendData(string data)
        {
            p.outputStream.WriteLine("DATA:" + data.Replace(":", "DP_"));
        }
    }

    public class Link { public string URL { get; private set; } public string UsableURL { get { return URL.Replace(":", "DP_"); } } public Link(string url) { URL = url; } }
}
