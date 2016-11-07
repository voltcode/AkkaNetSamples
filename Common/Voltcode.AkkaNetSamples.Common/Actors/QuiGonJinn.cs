using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class QuiGonJinn : ReceiveActor
    {
        protected override void PreStart()
        {
            base.PreStart();
            Console.WriteLine("QuiGonJinn: We've reached Naboo.");
        }

        public QuiGonJinn()
        {
            Receive<ReportToBase>
                (
                _ =>
                {
                    Console.WriteLine("QuiGonJinn: I hear ya, will report immediately!");
                    Sender.Tell(new AmidalaIsSafe());
                });
        }
    }
}
