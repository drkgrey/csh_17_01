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
        protected static Worker[] _list;

        public static Worker[] Create()
        {
            _list = Worker.WorkerListRnd(n);
            return _list;
        }
        
        public static string[] Show()
        {
            string[] list = new string[_list.Length];
            var a = 0;
            
            foreach (var i in _list)
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
