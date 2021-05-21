using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace semaphore_1
{
    class Program
    {
        static Semaphore sem = new Semaphore(1, 1);
        static void Main()
        {
            
        }
        static void enter(object id)
        {
            Console.WriteLine(id + "wants to in ");
            sem.WaitOne();
            Console.WriteLine(id + "is in");
            Console.WriteLine(id + "is leaving");
            sem.Release();
        }
    }
}

