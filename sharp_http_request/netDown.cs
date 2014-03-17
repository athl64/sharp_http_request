using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace sharp_http_request
{
    class netDown
    {
        public string getR(string url)
        {
            WebClient cl = new WebClient();

            cl.Headers.Add("user-agent", "testing requester");
            Stream data = cl.OpenRead(url);
            StreamReader response = new StreamReader(data);
            string tmp;
            tmp = response.ReadToEnd();
            data.Close();
            response.Close();
            return tmp;
        }

        public List<string> parse(string xml)
        {
            List<string> result = new List<string>();
            string from = "<a href=\"javascript:;\" data-id=\"",
                to = "\" class=\"flag-btn th_purity\">",
                middle = "\" class=\"tag-btn th_tagit\"><span class=\"spr spr-small-tag-tagged\">",
                tmpStr = "";
            int start = 0;
            int end = 0;
            string[] delimiterFrom = { from };
            string[] delimiterTo = { to };
            string[] delimiterM = { middle };

            while(xml.IndexOf(from) >= 0 && xml.IndexOf(to) >= 0)
            {
                start = xml.IndexOf(from);
                end = xml.IndexOf(to);
                tmpStr = xml.Split(delimiterTo,StringSplitOptions.RemoveEmptyEntries)[0];
                tmpStr = tmpStr.Split(delimiterFrom, StringSplitOptions.RemoveEmptyEntries)[1];
                tmpStr = tmpStr.Split(delimiterM, StringSplitOptions.RemoveEmptyEntries)[0];
                Console.Write("part: " + tmpStr + "\r\n=====================================================\r\n");
                File.AppendAllText("lines.txt","part: " + tmpStr + "\r\n=====================================================\r\n");
                result.Add(tmpStr);
                xml = xml.Substring(end + 1);
            }

            return result;
        }
    }
}
