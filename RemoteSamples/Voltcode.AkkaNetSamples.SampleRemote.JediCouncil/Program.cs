using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Actors;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.SampleRemote.JediCouncil
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialization
            ActorSystem actorSystem = ActorSystem.Create("TheRepublic");

            Console.WriteLine("TheRepublic: We shall deploy QuiGonJinn to Naboo");

            IActorRef jediCommander = actorSystem.ActorOf<JediCommander>();
           
            //deploy remotely via config
            var remoteQuiGonJinn = actorSystem.ActorOf(Props.Create(() => new QuiGonJinn()), "QuiGonJinn");

            //kick off message exchange
            actorSystem.Scheduler.ScheduleTellOnce(TimeSpan.FromSeconds(30),
                remoteQuiGonJinn,         //whom to tell
                new ReportToBase(),        //what to say
                jediCommander);   //from who say it came?
            
            Console.ReadKey();

            //cleanup
            actorSystem.Terminate().Wait();
        }
    }
}
