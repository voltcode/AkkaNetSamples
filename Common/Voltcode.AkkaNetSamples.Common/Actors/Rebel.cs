using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Rebel : ReceiveActor
    {
        public Rebel()
        {
            Receive<Attack>(
                _ => Console.WriteLine("Rebel no " + Self.Path.Uid + ": Ready for action!"));
        }
    }
}
