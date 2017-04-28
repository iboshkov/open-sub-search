using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSubSearchLib;

namespace OpenSubSearchCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            FilenameParser parser = new FilenameParser("");
            Console.WriteLine(parser.parse());
            Console.ReadKey();
        }
    }
}
