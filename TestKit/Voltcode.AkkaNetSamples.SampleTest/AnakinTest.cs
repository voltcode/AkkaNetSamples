using Akka.Actor;
using Akka.TestKit.NUnit;
using NUnit.Framework;
using System;
using Voltcode.AkkaNetSamples.Common.Actors;
using Voltcode.AkkaNetSamples.Common.Messages;

namespace Voltcode.AkkaNetSamples.SampleTest
{
    [TestFixture]
    public class AnakinTest : TestKit
    {
        [Test]
        public void Anakin_Should_Silently_Fall_To_The_Dark_Side()
        {
            var actor = Sys.ActorOf(Props.Create(() => new Anakin()));

            actor.Tell(new ComeToTheDarkSide());

            ExpectNoMsg();            
        }       

        [Test]
        public void QuiGonJinn_Must_Report_Back()
        {            
            var quigon = Sys.ActorOf(Props.Create(() => new QuiGonJinn()));

            quigon.Tell(new ReportToBase());

            var msg = ExpectMsg<AmidalaIsSafe>(TimeSpan.FromMilliseconds(100));
        }
    }
}
