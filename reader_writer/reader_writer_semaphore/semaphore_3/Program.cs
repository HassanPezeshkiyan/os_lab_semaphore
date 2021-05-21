using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace semaphore_3
{
    //reader_writer

    class Program
    {
        static string object_ = "-";
        static SemaphoreSlim mutex = new SemaphoreSlim(15);
        static SemaphoreSlim wrt = new SemaphoreSlim(10);
        //static Semaphore mutex = new Semaphore(1,2);
        //static Semaphore wrt = new SemaphoreSlim(1,2);
        static int reader_counter = 0;
        static int i, j = 0;
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "main";
            Thread wr = new Thread(writer);
            Thread re = new Thread(reader);
            wr.Name = "writer ";
            re.Name = "reader ";
            wr.Start();
            re.Start();
            Console.ReadKey();
        }
        static void writer()
        {
            
            do
            {
                wrt.Wait();
                Console.WriteLine("thread :" + " " + Thread.CurrentThread.Name);
                object_ += "*";
                wrt.Release();
                i++;
            }
            while (i<=4);

        }
        static void reader()
        {
           
            do
            {
                mutex.Wait();
                reader_counter += 1;
                if (reader_counter == 1)
                {
                    wrt.Wait();
                }
                mutex.Release();
                Console.WriteLine("thread :" + " " + Thread.CurrentThread.Name);
                Console.Write(object_ + "\n");
                mutex.Wait();
                reader_counter -= 1;
                if (reader_counter == 0)
                {
                    wrt.Release();
                    mutex.Release();
                }
                j++;
            } while (j<=9);

        }

    }
}
