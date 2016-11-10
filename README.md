# AkkaNetSamples

This project aims to provide an easy to digest introduction to the most important concepts in the Akka.NET world through a set of short code samples.

It has been developed as part of Akka.NET presentation I presented on the 3rd Nov 2016 in Gdansk at the [local .NET user group] (https://www.meetup.com/TG-NET) 

Slides (in English) are [available here](http://www.slideshare.net/KonradDusza1/actor-model-in-net-akkanet-68611742)


Akka.NET is a port of Akka framework on JVM that implements the Actor Model and provides many utilities for building highly available and robust systems.

If you're new to Actor Model and Akka.NET, I recommend studying the samples in the following order:
* LocalSamples
  * SampleLocal
  * SampleRouting
  * SampleSupervision
* RemoteSamples
* Cluster
* TestKit
* Streams



I'd like to thank the amazing Akka.NET and Akka contributors for creating the framework and providing a throrough documentation that helped me learn Akka.NET fundamentals.

I hope you find this material useful. If you are interested in a more in-depth course, I fully recommend completing the [Petabridge Bootcamp](https://petabridge.com/bootcamp/).

Comments and PRs are welcome!

## How to run the samples

Samples were developed using VS 2015, .NET Framework 4.5.2 and Akka.NET framework 1.1.2.

Clone the repository, open up the solution in Visual Studio and go through the samples in the order presented at the top of this page.

Each folder has its own Readme describing the scenario in the sample - make sure you read it before you start to analyze the code!
