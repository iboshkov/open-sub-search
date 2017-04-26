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
            FilenameParser parser = new FilenameParser("Fifty.Shades.Darker.2017.UNRATED.1080p.WEB-DL.DD5.1.H264-FGT");
            Console.WriteLine(parser.parse());
            Console.ReadKey();
        }
    }
}
