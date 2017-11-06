using System.Threading.Tasks;
using Orleans;
using Interfaces;
using System;

namespace Grains
{
    /// <summary>
    /// Grain implementation class Grain1.
    /// </summary>
    public class Person : Grain, IPerson
    {
        public Task SayHelloAsync(string message)
        {
            string name = this.GetPrimaryKeyString();
            Console.WriteLine($"{name} says: {message}");

            return Task.CompletedTask;
        }
    }
}
