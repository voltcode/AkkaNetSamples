using Akka.Actor;
using System;

namespace Voltcode.AkkaNetSamples.SampleCluster.TieFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem actorSystem = ActorSystem.Create("Empire");

            // this tie fighter will be later commanded by the battleship
            actorSystem.ActorOf<Common.Actors.TieFighter>("tiefighter");
            
            Console.ReadKey();

            actorSystem.Terminate().Wait();
        }
    }
}
