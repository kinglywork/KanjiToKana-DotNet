using KanjiToKana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanjiToKanaRunner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("use source string as the only parameter.");
                return;
            }            

            string source = args[0];
            string result = KanjiToKanaConverter.Convert(source, Mode.FullWidthKana);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
