using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csh_20_01
{
    class WorkersList: IEnumerable<Worker>
    {
        public static int n;
        
        public static string[] Show()
        {
            var worker = Worker.WorkerListRnd(n);
            string[] list = new string[worker.Length];
            var a = 0;
            Array.Sort(worker, new CompareBySalary());
            foreach (var i in worker)
            {
                list[a] = i.Show();
                a++;
            }
            return list;
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            return Worker.WorkerListRnd(n).Cast<Worker>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }




    }
}
