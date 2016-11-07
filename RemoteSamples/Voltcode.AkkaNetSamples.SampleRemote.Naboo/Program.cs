using Akka.Actor;
using System;

namespace Voltcode.AkkaNetSamples.SampleRemote.Naboo
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialization
            ActorSystem actorSystem = ActorSystem.Create("Naboo");
            
            Console.ReadKey();

            //cleanup
            actorSystem.Terminate().Wait();
        }
    }
}
