using Akka.Actor;
using System;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Battleship : ReceiveActor
    {
        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("I AM AN IMPERIAL BATTLESHIP");
        }        
    }
}
