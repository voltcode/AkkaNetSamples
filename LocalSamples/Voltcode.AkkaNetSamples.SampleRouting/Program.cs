using Akka.Actor;
using Akka.Routing;
using System;
using System.Linq;
using Voltcode.AkkaNetSamples.Common.Actors;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.SampleRouting
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialization
            ActorSystem actorSystem = ActorSystem.Create("GalaxyFarFarAway");

            //pool router creates his children
            var commanderProps = Props.Create<Trooper>().WithRouter(new BroadcastPool(5));
            var commander = actorSystem.ActorOf(commanderProps, "Commander");
            commander.Tell(new Attack());

            // group router requires the routees to be present
            var rebels = Enumerable.Range(1, 5).Select(x => actorSystem.ActorOf<Rebel>("Rebel" + x.ToString()));

            var rebelLeaderProps = Props.Create<Rebel>().WithRouter(new BroadcastGroup(rebels.Select(x=>x.Path.ToString())));
            var rebelLeader = actorSystem.ActorOf(rebelLeaderProps, "RebelLeader");
            rebelLeader.Tell(new Attack());

            Console.ReadKey();

            Console.WriteLine("Admiral: We must deploy more troopers!!! Hit it commander!");

            Console.ReadKey();

            var commanderZwei = actorSystem.ActorOf(Props.Create<Trooper>().WithRouter(FromConfig.Instance), "TeamZwei");
            commanderZwei.Tell(new Attack());
            commanderZwei.Tell(new Attack());
            commanderZwei.Tell(new Attack());
            commanderZwei.Tell(new Attack());
            commanderZwei.Tell(new Attack());

            Console.ReadKey();

            //cleanup
            actorSystem.Terminate().Wait();
        }        
    }
}
