using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace periority
{
    class Program
    {
        //اولویت بندی thread
        static int object_ = 0;
        static void Main(string[] args)
        {
            Thread th_1 = new Thread(increase_);
            Thread th_2 = new Thread(decrease_);
            th_1.Name = "increase thread";
            th_2.Name = "decrease thread";
            th_1.Priority = ThreadPriority.Lowest;
            th_2.Priority = ThreadPriority.Highest;
            th_1.Start();
            th_2.Start();
            Thread.Sleep(1000);
            Console.ReadKey();
        }
        static void increase_()
        {
            
            Console.WriteLine(Thread.CurrentThread.ThreadState);
            Console.WriteLine(Thread.CurrentThread.Priority);
            Console.Write(Thread.CurrentThread.Name + "\n");
            object_ += 1;

        }
        static void decrease_()
        {
            Console.Write(Thread.CurrentThread.Name + "\n");
            Console.WriteLine(Thread.CurrentThread.Priority);//نمایش وضعیت اولویت
            object_ -= 1;
            Console.WriteLine(object_.ToString());

        }
    }
}
