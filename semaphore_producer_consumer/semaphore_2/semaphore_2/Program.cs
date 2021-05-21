using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace semaphore_2
{
    class Program
    {
        static int n = 8;
        static char[] buffer = new char[8];
        static Semaphore mutex = new Semaphore(1, n);
        static Semaphore full = new Semaphore(0, n);
        static Semaphore empty = new Semaphore(n, n);
        static int p = 0;
        static int in_, out_ = 0;
        static char item = '-';
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Thread p = new Thread(producer);
            Thread c = new Thread(consumer);
            p.Start();
            c.Start();
            p.Name = "producer_thread";
            c.Name = "consumer_thread";
            Console.WriteLine("thread_name:"+" "+Thread.CurrentThread.Name);
            for (int i = 0; i < 8; i++) { Console.WriteLine(buffer[i]); }
            Console.ReadKey();
        }
        static void producer()
        {


            empty.WaitOne();
            mutex.WaitOne();
            while (p == n)
            { }
            Console.WriteLine("thread name:" + "" + Thread.CurrentThread.Name);
            buffer[in_] = '*';
            in_ = (in_ + 1) % n;
            p++;
            mutex.Release();
            full.Release();


        }
        static void consumer()
        {


            full.WaitOne();
            mutex.WaitOne();
            while (p == 0)
            { }
            Console.WriteLine("thread name:" + "" + Thread.CurrentThread.Name);
            item = buffer[out_];
            out_ = (out_ + 1) % n;
            p--;
            empty.Release();
            mutex.Release();

        }
    }
}
