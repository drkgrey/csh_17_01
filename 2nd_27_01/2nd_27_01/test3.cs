using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_27_01
{
    class test3
    {
        public static void test()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
            {"four",4 },
            {"two",2 },
            { "one",1 },
            {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("");
            var c = dict.OrderBy(pair => pair.Value);
            foreach (var pair in c)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("");
            Func<KeyValuePair<string, int>, int> predicate = Order;
            var e = dict.OrderBy(predicate);
            foreach (var pair in e)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

        }
        static int Order(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
