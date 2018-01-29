using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_27_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dz dz = new Dz();
            dz.FillListInt();
            Console.WriteLine("");
            dz.CountInt();
            Console.WriteLine("");
            dz.FillListObj();
            dz.CountObj();
            Console.WriteLine("");
            test3.test();
            Console.ReadKey();
        }
    }
}
