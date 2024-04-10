using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoThreadTask
{
    public class ThreadWorker
    {
        /*
         * Delegate
         */

        // type 
        public delegate int SomeMethodType(int x, int y);

        // erklære
        SomeMethodType metoderef;


        public void TestDelegate()
        {
            metoderef = 
                (k, l) => 
                { 
                    Console.WriteLine("Anonym: x,y = " + k + ", " + l); 
                    return k + l; 
                };


            // brug metode
            int sum = metoderef(55, 62);
            Console.WriteLine(sum);

            metoderef += Gange;
            int res = metoderef(55, 2);
            Console.WriteLine(res);




            metoderef -= Gange;
            res = metoderef(2, 62);
            Console.WriteLine(res);
        }


        public int Gange(int i, int j)
        {
            Console.WriteLine("Kendt: x,y = " + i + ", " + j);
            return i * j;
        }





        /*
         * Threading
         */

        private static bool done = false; // Static fields are shared between all threads

        public void ExampleThread()
        {
            Thread t1 = new Thread(Go);
            t1.Start();
            Go();
        }

        private void Go()
        {
            if (!done) {  done = true; Console.WriteLine("Done"); }
        }





        // show concurrency
        public void StartTaskTest()
        {
            Task t1 = Task.Run(() => DoWork("Number One", ConsoleColor.Red));
            Task t2 = Task.Run(() => DoWork("Number Two", ConsoleColor.Green));

            //Thread.Sleep(1000);
            t1.Wait();
            t2.Wait();
        }

        private void DoWork(String name, ConsoleColor colour)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine($"Name {name} no={i}");
            }
        }



    }
}
