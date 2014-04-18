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
            string mode = "";

            if (args.Length > 0)
            {
                mode = args[0];
            }

            Console.Write("Wallbase.cc random wallpaper downloader\n\rby Dvixi :)\n\rLaunch parameters:\r\nquiet - close without confirmation\r\nhttp://dvixi.in.ua\r\n");

            sharp_request req = new sharp_request();
            string response = req.getR("http://wallbase.cc/search?section=wallpapers&q=abstract&res_opt=eqeq&res=1920x1080&thpp=60");

            List<string> lisp = req.parse(response);

            foreach (string Line in lisp)
            {
                //File.AppendAllText("lines.txt",Line + "\r\n");
                Console.Write("pull " + Line + " ");
                if (req.getFile(Line))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\tOK\n\r");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\tOOPS...\n\r");
                    Console.ResetColor();
                }
            }

            if (mode == "quiet")
            {
                Console.Write("done, closing....");
            }
            else
            {
                Console.Write("done, press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
