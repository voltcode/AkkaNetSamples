using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Trooper : ReceiveActor
    {
        public Trooper()
        {
            Receive<Attack>(
                msg =>
                {
                    Console.WriteLine("Trooper No " + Self.Path.Uid + " :Yes, Sir!");
                });
        }
    }
}
