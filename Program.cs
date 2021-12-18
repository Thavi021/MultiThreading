using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => doSomeWork(1,2000));
            t1.Start();
            var t2 = new Task(() => doSomeWork(2,5000));
            t2.Start();
            var t3 = new Task(() => doSomeWork(3,7000));
            t3.Start();
            var t4 = new Task(() => doSomeWork(4,10000));
            t4.Start();

            Task T1 = Task.Factory.StartNew(() => doSomeWork(1, 2000)).ContinueWith((prev)=> doSomeMoreImportantWork(1,3000));
            Task T2 = Task.Factory.StartNew(() => doSomeWork(2, 5000)).ContinueWith((prev) => doSomeMoreImportantWork(2, 7000));
            Task T3 = Task.Factory.StartNew(() => doSomeWork(3, 7000)).ContinueWith((prev) => doSomeMoreImportantWork(3, 10000));


            Console.ReadLine();
        }

        static void doSomeWork(int id,int sleep)
        {
            Console.WriteLine("Ask {0} is  beginning",id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} is completed",id);
        }

        static void doSomeMoreImportantWork(int id, int sleep)
        {
            Console.WriteLine("Another Task {0} is beginning", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Another Task {0} is completed",id);
        }
    }
}
