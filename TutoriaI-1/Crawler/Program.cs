using System;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        private static void showMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            ArrayList arr = new ArrayList();
            foreach (Match m in mc)
            {
                if (!arr.Contains(m.Value.ToString()))
                {
                    arr.Add(m.Value.ToString());
                }
            }
            if (arr.Count == 0)
            {
                Console.WriteLine("E-mail addresses not found");
            }
            else
            {
                foreach (object email in arr)
                    Console.WriteLine(email);
            }
        }

        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    if (args.Length == 0 || args == null) throw new ArgumentNullException("The value of argument was not entered");
                    HttpResponseMessage result = await httpClient.GetAsync(args[0]);
                    if (!result.IsSuccessStatusCode) throw new Exception("Error while downloading the page");
                    string content = await result.Content.ReadAsStringAsync();
                    showMatch(content, @"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");
                }
                catch (System.InvalidOperationException)
                { Console.WriteLine("The passed parameter is not a valid URL"); }
            }
        }
    }
}