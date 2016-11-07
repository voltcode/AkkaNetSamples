using Akka.Actor;
using Akka.Routing;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.SampleCluster.Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem actorSystem = ActorSystem.Create("Empire");

            // instantiate the Battleship actor with router to pass commands to tie fighters
            var battleshipProps = Props.Create<Common.Actors.Battleship>().WithRouter(FromConfig.Instance);
            var battleship = actorSystem.ActorOf(battleshipProps, "battleship");

            // when the cluster is formed, start sending messages to the battleship,
            // which will route them to the fighters
            Akka.Cluster.Cluster.Get(actorSystem).RegisterOnMemberUp(
                () =>
                {
                    actorSystem.Scheduler.ScheduleTellRepeatedly(
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        battleship,
                        new TurnLeft(),
                        Nobody.Instance);

                    actorSystem.Scheduler.ScheduleTellRepeatedly(
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(2),
                        battleship,
                        new TurnRight(),
                        Nobody.Instance);
                    
                });

            Console.ReadKey();
            actorSystem.Terminate().Wait();
        }
    }
}
