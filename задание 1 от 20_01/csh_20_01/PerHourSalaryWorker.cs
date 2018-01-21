using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_20_01
{
    class PerHourSalaryWorker:Worker
    {
        double hourRate;
        public PerHourSalaryWorker(double HourRate)
        {
            hourRate = HourRate;
        }
        
        public override void Salary()
        {
           monthSalary = 20.8*8*hourRate;
        }
        public override string Show()
        {
            
            string a = "";
            a += _fio +" salary:"+ monthSalary.ToString()+"\n";
            return a;
        }
        public override void Name()
        {
            var nameList = new string[] { "Hour1", "Hour2", "Hour3", "Hour4", "Hour5", "Hour6" };
            _fio = nameList[random.Next(0, nameList.Length)];
        }
    }
}
