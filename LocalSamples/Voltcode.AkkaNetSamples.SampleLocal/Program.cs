using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Actors;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.SampleLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialization
            ActorSystem actorSystem = ActorSystem.Create("GalaxyFarFarAway");

            IActorRef anakin = actorSystem.ActorOf<Anakin>("Anakin");

            //kick off message exchange
            actorSystem.Scheduler.ScheduleTellOnce(TimeSpan.FromSeconds(1), 
                anakin,         //whom to tell
                new Start(),        //what to say
                Nobody.Instance);   //from who say it came?

            actorSystem.Scheduler.ScheduleTellOnce(TimeSpan.FromSeconds(2),
                anakin,         //whom to tell
                new ComeToTheDarkSide(),        //what to say
                Nobody.Instance);   //from who say it came?

            Console.ReadKey();

            //cleanup
            actorSystem.Terminate().Wait();
        }
    }
}
