using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IOOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int c;
            String s = null;
            WriteFile("..\\..\\text2.txt");
            ReadWeb("https://www.google.pl/?gws_rd=ssl#q=c%23+read+from+url");
            
            Console.ReadKey();

        }

        static void ReadFile(String path) 
        {
            int c;
            StreamReader sr = new StreamReader(path);
            for (int i = 0; i < 10 && (c = sr.Read()) > -1; i++)
            {
                Console.WriteLine((char)c);
                if (((char)c) == 'c') throw new IOException("NIe lubie c");
            }
        }
        static void WriteFile(String path)
        {
            int c;
            StreamWriter sw = new StreamWriter(path);
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    sw.Write(i * j);
                    sw.Write("\t");

                }
                sw.WriteLine();
            }
            sw.Close();
        }

        static void ReadWeb(String addres)
        {
            WebClient wc = new WebClient() ;
            wc.Headers.Set(HttpRequestHeader.UserAgent, "Mozilla / 5.0(Macintosh; U; Intel Mac OS X 10.4; en - US; rv: 1.9.2.2) Gecko / 20100316 Firefox / 3.6.2");
            String page = wc.DownloadString(addres);
            Console.WriteLine(page);
            StreamWriter sw = new StreamWriter("..\\..\\g2.html");
            sw.WriteLine(page);
            sw.Close();
        }
    }
}
