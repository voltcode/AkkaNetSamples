using Akka.Actor;
using System;

namespace Voltcode.AkkaNetSamples.SampleCluster.TieFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem actorSystem = ActorSystem.Create("Empire");

            actorSystem.ActorOf<Common.Actors.TieFighter>("tiefighter");
            
            Console.ReadKey();

            actorSystem.Terminate().Wait();
        }
    }
}
