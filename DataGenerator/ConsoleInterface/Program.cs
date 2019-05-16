using Generator;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleInterface
{
    class Program
    {
        static void Main()
        {
            AsyncContext.Run(() => MainAsync());
        }
        static async void MainAsync()
        {
            var sender = new Sender.Sender();
            while (true)
            {
                await sender.SendDataAsync();
                Console.WriteLine($"{DateTime.Now} New data generated and send to database.");
                Thread.Sleep(5000);
            }
        }
    }
}
