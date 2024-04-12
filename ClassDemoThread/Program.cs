// See https://aka.ms/new-console-template for more information

using ClassDemoThread;
using ClassDemoThreadTask;

ThreadWorker worker = new ThreadWorker();

//worker.TestDelegate();


//worker.ExampleThread();

//worker.StartTaskTest();

//Thread.Sleep(1000);

AnotherWorker w2 = new AnotherWorker();
w2.Start();



Console.ReadLine();



