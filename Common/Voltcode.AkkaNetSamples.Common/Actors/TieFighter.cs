using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class TieFighter : ReceiveActor
    {
        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("Tie Fighter reporting for duty");
        }
        public TieFighter()
        {
            Receive<TurnLeft>( _ => Console.WriteLine("Roger that, turning left"));
            Receive<TurnRight>(_ => Console.WriteLine("Aye Sir, turning right"));
        }
    }
}
