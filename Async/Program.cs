using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main()
        {            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task1(cancellationTokenSource.Token, 40000);
            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();


            Console.ReadKey();
        }

        private static async void Task1(CancellationToken cancellationToken, int num)
        {
            await Task.Run(() =>
            {
                Task2(cancellationToken, num);
            }, cancellationToken);
        }

        private static async void Task2(CancellationToken cancellationToken, int num)
        {
            await Task.Run(() =>
            {
                while (num-- > 0) Console.WriteLine(num);
            }, cancellationToken);
        }

       
    }
}

