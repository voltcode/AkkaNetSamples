using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class RandomJedi : UntypedActor
    {    
        protected override void OnReceive(object message)
        {
            if (message is HeyWatchMe)
            {
                Context.Watch(Sender);
                Console.WriteLine("Jedi: I started watching the droid");
            }
            else if (message is Terminated)
            {
                Terminated msg = message as Terminated;
                Console.WriteLine("Jedi: I saw a droid crash, his name was: "
                                + msg.ActorRef.Path.Name);
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
