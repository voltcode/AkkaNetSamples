using Akka.Actor;
using Akka.Streams;
using Akka.Streams.Dsl;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Voltcode.AkkaNetSamples.SampleStream
{
    // adapted from https://github.com/akkadotnet/akka.net/tree/dev/src/examples/Streams/StreamsExamples
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var oneSecond = TimeSpan.FromSeconds(1);

            using (var system = ActorSystem.Create("system"))
            using (var materializer = system.Materializer())
            {
                var sithTemptationSource = Source.Tick(oneSecond, oneSecond, "Come to the dark side");
                var flow = Flow.Create<string>()
                    .Select(s => s.ToUpper())                  
                    .Intersperse(", ");
                var naiveJediBrainSink = Sink.ForEach<string>(Console.WriteLine);

                var runnableGraph = sithTemptationSource.Via(flow).ToMaterialized(naiveJediBrainSink, Keep.Right);
                await runnableGraph.Run(materializer);
            }
        }
    }
}
