using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class JediCommander : ReceiveActor
    {
        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("I shall monitor our mission on Naboo");
        }        
       
        public JediCommander()
        {            
            Receive<AmidalaIsSafe>(
                _ => Console.WriteLine("JediCommander: QuiGon reports Amidala is safe"));
        }
    }
}
