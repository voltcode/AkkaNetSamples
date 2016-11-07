using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Anakin : UntypedActor
    {       
        protected override void OnReceive(object message)
        {
            if (message is Start)
            {                
                IActorRef kid = Context.ActorOf<Luke>("Luke");
                Console.WriteLine("Anakin: I'm going to be a father!");
            }          
            else if (message is ComeToTheDarkSide)
            {
                Become(DarthVader());
                Console.WriteLine("Anakin: I'm Darth Vader now");
                                   
                IActorRef kid = Context.Child("Luke");
                Console.WriteLine("Vader: Luke, I am your father");
                kid.Tell(new IamYourFather());
            }            
        }

        private UntypedReceive DarthVader()
        {
            return new UntypedReceive(message =>
            {
                if (message is NoooNotTrue)
                {
                    Console.WriteLine("Vader: Luke is in denial. I am such a lousy dad.");
                }
            });
        }
    }
}
