using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_20_01
{
    abstract class Worker
    {
        protected string _fio;
        internal double monthSalary;
        public static Random random;

        public abstract void Salary();
        public abstract string Show();
        public abstract void Name();
        public static Worker[] WorkerListRnd(int n)
        {
            random = new Random();
            var list = new Worker[n];
            for (int i = 0; i < list.Length; i++)
            {
                if (random.Next(1, 3) == 1) { list[i] = new PerHourSalaryWorker(random.Next(1, 15)); }
                else list[i] = new FixedSalaryWorker(random.Next(500, 2000));
                list[i].Salary();
                list[i].Name();
            }
            return list;
        }
    }
}
