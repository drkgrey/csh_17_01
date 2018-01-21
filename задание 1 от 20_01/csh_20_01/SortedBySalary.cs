using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_20_01
{
    class CompareBySalary: IComparer<Worker>
    {
        public int Compare(Worker p1, Worker p2)
        {
            if (p1.monthSalary > p2.monthSalary)
                return 1;
            else if (p1.monthSalary < p2.monthSalary)
                return -1;
            else
                return 0;
        }
    }
}
