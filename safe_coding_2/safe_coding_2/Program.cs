using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace safe_coding_2
{
    class Program
    {
        static List<string> list = new List<string>();
        static void Main(string[] args)
        {
            new Thread(additems).Start();
            new Thread(additems).Start();
            Console.ReadKey();
        }
        static void additems()
        {
            for (int i = 0; i < 100; i++)
                lock (list)
                    list.Add("item " + list.Count);
            string[] items;
            lock (list)
                items = list.ToArray();
            foreach (string s in items) Console.Write(s + "\t");
        }
    }
}
