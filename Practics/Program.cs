using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practics.LianXi;

namespace Practics
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMan testMan = new TestMan();
            testMan.Test(enKnowledge.enKnowledge_Sort, (int)enSort.enSort_Max);
            Console.ReadLine();
        }
    }
}
