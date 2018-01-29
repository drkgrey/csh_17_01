using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_27_01
{
    class Dz
    {
        List<object> listObj = new List<object>();
        List<int> listInt = new List<int>();
        Dictionary<object, int> val = new Dictionary<object, int>();

        public void FillListInt()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                listInt.Add(rnd.Next(0, 10));
                Console.WriteLine(listInt[i]);
            }
        }
        public void FillListObj()
        {
            listObj.Add(listInt);
            listObj.Add(listInt);
            listObj.Add(listInt);
            listObj.Add(val);
            listObj.Add(val);
            listObj.Add(val);
            listObj.Add(listInt);
            listObj.Add(listInt);
        }
        public void CountObj()
        {
            foreach (object c in listObj)
            {
                if (val.ContainsKey(c))
                {
                    val[c]++;
                }
                else val.Add(c, 1);
            }
            foreach (KeyValuePair<object, int> b in val)
            {
                var c = b.Key.ToString();
                Console.WriteLine($"элемент {c} встречается - {b.Value} раз");
            }
        }
        public void CountInt()
        {
            Dictionary<int, int> valI = new Dictionary<int, int>();
            foreach(int c in listInt)
            {
                if (valI.ContainsKey(c)) valI[c]++; else valI.Add(c, 1);
            }
            foreach (KeyValuePair<int,int> b in valI)
            {
                Console.WriteLine($"элемент {b.Key} встречается - {b.Value} раз");
            }
            Console.WriteLine("");

            var count = listInt.Distinct();
            foreach(var b in count)
            {
                Console.WriteLine($"{b} встречается {listInt.Count(x => x==b)} раз");
            }
        }
        

    }
}
