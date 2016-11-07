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

            IActorRef droid = actorSystem.ActorOf<Droid>("Droid");

            IActorRef jedi = actorSystem.ActorOf<RandomJedi>("Jedi");

            //kick off message exchange
            actorSystem.Scheduler.ScheduleTellOnce(TimeSpan.FromSeconds(1),
                //actorSystem.Scheduler.ScheduleTellRepeatedly(TimeSpan.FromSeconds(1),
                //TimeSpan.FromMilliseconds(500),
                droid,         //whom to tell
                new PleaseCrash(),        //what to say
                Nobody.Instance);   //from who say it came?

            Console.ReadKey();

            //cleanup
            actorSystem.Terminate().Wait();
        }
    }
}
