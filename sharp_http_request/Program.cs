using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using sharp_request = sharp_http_request.netDown;

namespace sharp_http_request
{
    class Program
    {
        static void Main(string[] args)
        {
            sharp_request req = new sharp_request();
            string response = req.getR("http://wallbase.cc/random");
            string pathToFile = "htmlResponse.html";

            List<string> lisp = req.parse(response);
            
            File.WriteAllText(pathToFile,response);

            Console.ReadKey();
        }
    }
}
