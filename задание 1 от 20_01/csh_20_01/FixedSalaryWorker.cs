using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_20_01
{
    class FixedSalaryWorker:Worker
    {
        double fixedSalary;
        public FixedSalaryWorker(double FixedSalary)
        {
            fixedSalary = FixedSalary;
        }
        public override void Salary()
        {
            monthSalary = fixedSalary;
        }
        public override string Show()
        {
            string a = "";
            a += _fio + " salary:" + monthSalary.ToString() + "\n";
            return a;
        }
        public int CompareTo(object obj)
        {
            return _fio.CompareTo(obj.ToString());
        }
        public override void Name()
        {
            var nameList = new string[] { "Fixed", "Fixed2", "Fixed3", "Fixed4", "Fixed5", "Fixed6" };
            _fio = nameList[random.Next(0, nameList.Length)];
        }
    }
}
