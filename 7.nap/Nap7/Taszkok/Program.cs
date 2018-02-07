using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Taszkok
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(); // ADO
            CancellationToken token1 = cts.Token;
            CancellationToken token2 = cts.Token;
            token1.Register(() => { Console.WriteLine("token1 lett ertesitve, sajattask megdoglott"); });
            ManualResetEvent mre = new ManualResetEvent(false);

            Task sajattask = new Task(
                () =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        token1.ThrowIfCancellationRequested();
                        Console.WriteLine("szam: "+i);
                        Thread.Sleep(300);
                    }
                    throw new InvalidOperationException("valami gebasz tortent");
                },token1
                );
            Task<int> sajattask2 = new Task<int>(
                () =>
                {
                    int sum = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        sum += i;
                        WaitHandle[] wh = new WaitHandle[] { mre, token2.WaitHandle };
                        WaitHandle.WaitAny(wh, 100);

                        token2.ThrowIfCancellationRequested();
                        Console.WriteLine("+szam: " + i);
                        Thread.Sleep(300);
                    }
                    return sum;
                }, token2
                );

            Console.WriteLine("status: " + sajattask.Status);
            sajattask.Start();
            sajattask2.Start();
            mre.Set();
            Console.WriteLine("status: " + sajattask.Status);
            Thread.Sleep(1000);
            Console.WriteLine("status: " + sajattask.Status);

            cts.Cancel();

            try
            {
                sajattask.Wait();
                Console.WriteLine("status: " + sajattask.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Console.WriteLine(e.ToString());
                Console.WriteLine(e.InnerException.Message);
            }
            Console.WriteLine("status: " + sajattask.Status);
            

            //sajattask.Start();

            Console.ReadLine();

        }
    }
}
