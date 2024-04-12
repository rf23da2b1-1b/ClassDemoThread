using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoThread
{
    public class AnotherWorker
    {
        private Random _rnd = new Random(DateTime.Now.Microsecond);

        private Semaphore sem = new Semaphore(10,20);

        public void Start()
        {
            Task t1 = Task.Run(() => Sender());
            Task t2 = Task.Run(() => Modtager());

            t1.Wait();
            t2.Wait();
        }



        public void Sender()
        {
            for (int i = 0; i < 20; i++) 
            {
                sem.WaitOne();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Item {i} ");
                Thread.Sleep(_rnd.Next(30));
                Console.WriteLine("er sendt");
            }
        }

        public void Modtager()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(_rnd.Next(30));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Item {i} er modtaget");
                sem.Release();
            }
            Console.ReadLine();

            for (int i = 5; i < 20; i++)
            {
                Thread.Sleep(_rnd.Next(30));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Item {i} er modtaget");
                sem.Release();
            }
        }
    }
}
