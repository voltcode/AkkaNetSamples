using Akka.Actor;
using System;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.Common.Actors
{
    public class Luke : ReceiveActor
    {
        private string currentThought;
                  
        public Luke()
        {            
            Receive<IamYourFather>(
                msg =>
                {
                    if (Sender.Path.Name == "Anakin")
                    {
                        currentThought = "I don't believe it! He's just cut off my hand!";                        
                        Sender.Tell(new NoooNotTrue());
                    }
                    else
                    {
                        currentThought = "Yeah, whatever.";
                    }

                    Console.WriteLine("Luke:" + currentThought);
                });
        }        
    }
}
