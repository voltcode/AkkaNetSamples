using Akka.Actor;
using System;

using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Droid : TypedActor, IHandle<PleaseCrash>, IHandle<IamYourFather>
    {
        protected override void PreStart()
        {
            base.PreStart();
            Context.ActorSelection("/user/Jedi").Tell(new HeyWatchMe());
        }

        protected override void PreRestart(Exception reason, object message)
        {
            base.PreRestart(reason, message);
            Console.WriteLine("FATAL FAILURE, RESTARTING");            
        }

        protected override void PostRestart(Exception reason)
        {
            base.PostRestart(reason);
            Console.WriteLine("DROID RESTARTED");           
        }

        public void Handle(IamYourFather message)
        {
            Console.WriteLine("I don't understand. Bzz. Bzz.");
        }

        public void Handle(PleaseCrash message)
        {
            Console.WriteLine("OK! Crashing now!");
            Self.GracefulStop(TimeSpan.FromMilliseconds(100));
            // replacing GracefulStop with the below line (throw new Exception) will cause the actor to restart. 
            // Terminated message would not be triggered.
            //throw new Exception(); 
        }
    }
}
