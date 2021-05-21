using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace intrupt_method
{
    class Program
    {
        static int object_ = 0;
        static void Main(string[] args)
        {
            Thread th_1 = new Thread(increase_);
            Thread th_2 = new Thread(decrease_);
            th_1.Name = "increase thread";
            th_2.Name = "decrease thread";
            th_1.Start();
            th_2.Start();
            th_1.Interrupt();//intrupt take out thread from infinite sleep
            Console.ReadKey();
        }
        static void increase_()
        {
            //Thread.Sleep(5000);
            
            try
            {
                Thread.Sleep(Timeout.Infinite);//همیشه در حالت اسلیپ میمونه 
            }
            catch
            {
                Console.WriteLine("intrupted exception raised");
            }
            Console.WriteLine(Thread.CurrentThread.ThreadState);
            Console.Write(Thread.CurrentThread.Name + "\n");
            object_ += 1;

        }
        static void decrease_()
        {
            Console.Write(Thread.CurrentThread.Name + "\n");
            object_ -= 1;
            Console.WriteLine(object_.ToString());

        }
    }
}
