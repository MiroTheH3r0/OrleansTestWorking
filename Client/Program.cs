using System;
using System.Threading;
using Orleans;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;
using Orleans.Runtime;
using Interfaces;

namespace Client
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";

            // Then configure and connect a client.
            var clientConfig = ClientConfiguration.LoadFromFile("ClientConfiguration.xml");
            while (true)
            {
                try {
                    GrainClient.Initialize(clientConfig);
                    Console.WriteLine("Connected to silo!");

                    var friend = GrainClient.GrainFactory.GetGrain<IPerson>("Joe");
                    var result = friend.SayHelloAsync("Hello!");

                    Console.ReadLine();
                    break;
                }
                catch (SiloUnavailableException)
                {
                    Console.WriteLine("Silo not available! Retrying in 3 seconds.");
                    Thread.Sleep(3000);
                }
            }
            //var client = new ClientBuilder().UseConfiguration(clientConfig).Build();
            //client.Connect().Wait();

            //Console.WriteLine("Client connected.");

            //
            // This is the place for your test code.
            //

        }
    }
}
