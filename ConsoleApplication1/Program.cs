using pp_lr_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static string fullText = @"
using pp_lr_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 0;
            float qwerty = 0.0;
            int g = 0;
            float str = 0.0;
            method(ref r, ref g, ref b, ref str, ref ca);
            r = g;
            Console.WriteLine();
            Console.ReadKey();
            str = qwerty;
        }
    }
}";
private static string selectedText = @"
            int g = 0;
            float str = 0.0;
            method(ref r, ref g, ref b, ref str, ref ca);
            r = g;
            Console.WriteLine();
            Console.ReadKey();
            str = qwerty;";


        static void Main(string[] args)
        {
            Refactor refact = new Refactor("Filthy", selectedText, fullText);
            A ca = new A();
            ca.a = 0;
            int r = 0, g = 0, b = 0;
            string str = "";
            method(ref r, ref g, ref b, ref str, ref ca);

            Console.WriteLine(fullText);
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Console.WriteLine(selectedText);
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Console.WriteLine(refact.NewFullProgramText);
            
            Console.WriteLine();
            Console.ReadKey();
        }

        static void method(ref int r, ref int g, ref int b, ref string str, ref A ca)
        {
            r = 5;
            g = 5;
            b = 5;
            str = "12345";
            ca.a = 5;
        }

        public class A
        {
            public int a;
        }
    }
}
//"str = qwerty;\nmethod(ref r, ref g, ref b, ref str, ref ca);\nr = g;\nch = 'Y';\nstring local = \"\";"
//"string str = \"\";\nstring qwerty = \"\";\nint r = 0;\nint g = 0, b = 0;\nchar ch = 'Y';\n\nstr = qwerty;\nmethod(ref r, ref g, ref b, ref str, ref ca);\nr = g;\nch = 'Y';\nstring local = \"\";"