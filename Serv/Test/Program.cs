using System;
using System.Text.RegularExpressions;

namespace RegExApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "sdhedhiuhdh(&&(&(&Y(*&(*(*&111";
            Regex reg = new Regex("^[A-Za-z0-9]+$");
            MatchCollection result = reg.Matches(str);
            foreach (var item in result)
            {
                Console.Write(item.ToString());
            }
        }
    }
}