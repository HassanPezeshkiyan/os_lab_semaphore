using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace safe_coding
{
    class Program
    {
        static int x = 10;
        static Semaphore control = new Semaphore(1,2);
        static Object id = 0;
        static void Main(string[] args)
        {
            Thread t = new Thread(go);
            Thread t1 = new Thread(go1);
            t.Name = "thread_one";
            t1.Name = "thread_two";
            t1.Start();
            t.Start();
            Console.ReadKey();

        }
        static void go()
        {
            control.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + "wants to in ");
            x++;
            Console.WriteLine(Thread.CurrentThread.Name + "is in");
            Console.WriteLine(Thread.CurrentThread.Name + "is leaving");
            control.Release();
            Console.WriteLine(x);
        }
        static void go1()
        {
            control.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + "wants to in ");
            x = 123;
            Console.WriteLine(Thread.CurrentThread.Name + "is in");
            Console.WriteLine(Thread.CurrentThread.Name + "is leaving");
            control.Release();
            Console.WriteLine(x);
        }
    }
}
