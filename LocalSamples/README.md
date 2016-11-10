# Local samples

There are 3 samples in this pack:

* SampleLocal - presents Become mechanism
* SampleRouting - presents Routing mechanism
* SampleSupervision - presents Supervision mechanism

## State machines (SampleLocal)

This sample is designed to be the first to look at for a person that has never worked with Akka.NET or its JVM counterpart.

### Story

Anakin begets Luke. Some time later, he receives the Sith calling - "Come to the dark side". Anakin falls for it and becoms Darth Vader.
As Darth Vader, he tells Luke that he is his real father. Luke cannot accept the truth.

### How to run the sample

Run the project SampleLocal. The story will unfold by itself.

### Technical explanation

Several core Actor model and Akka.NET concepts are presented in this sample. First of all, a way to create child actors and naming them is presented in the OnReceive method.
Next, Become method is used to change Anakin's behavior. On the other hand, inside Luke's message handling logic we can see that Sender property is used to identify the message origin.

To facilitate story development, Scheduler (in Program.cs) is used to first send a Start message to Anakin, and later to pull him towards the way of the Sith.

#### Actors

* Anakin
* Luke (as child of Anakin)

#### Messages

* Start
* ComeToTheDarkSide
* IamYourFather
* NoooNotTrue

### More information

[The entire "Working with Actors" section](http://getakka.net/docs/#working-with-actors)

[Apart from creating actors, this sample presents on "Become" mechanism](http://getakka.net/docs/working-with-actors/Switchable%20Behaviors)

## Routing (SampleRouting)

### Story

In a galaxy far, far away, a group of Imperial Troopers and their Commander encounters a Rebel Leader and his Squad. To win the battle, Admiral deploys second batch of Troopers.

### How to run the sample

Run the project SampleRouting. The story will unfold by itself. When the rebel squad finishes printing messages - press space twice to finish the story.

### Technical explanation

The goal of this sample is to present Akka.NET routing capabilities and two ways of configuring routers. A router is a special kind of Actor, whose 
 core responsibility is to route messages to other Actors.

First, a Commander - router - is created and configured in code as a BroadcastPool router with pool size (Trooper count) equal to 5. Pool routers create Actors they route messages to. 
Broadcast routers pass the message to all of their routees.
Next, Commander is told to Attack. Being a router, he passes the command to his Troopers. We can observe five acknowledgments from Troopers on the console.

Time for some rebel action. Rebel actors are created in code, before the leader is created. Rebel Leader is a BroadcastGroup router, configured in code using the rebels that were created before.
His behavior is similar to the Commander's, meaning that given an Attack order, he passes it to his rebels.

Please note that the messages interleave on the console. If you rerun the sample, the message ordering will most likely be different. This means that under the hood, asynchronous behavior is occuring, as designed in the actor model.
After user presses a key twice, new Imperial Commander is created. This time using configuration, defined in the App.Config file. The Commander is a Round Robin Pool router, meaning it creates its own routees, and upon receiving a message, it routes it to a single child actor.  

#### Actors

* Trooper
* Rebel
* routers (Commander, RebelLeader, CommanderZwei)

#### Messages

* Attack

### More information

[To further investigate Akka.NET routing capabilities, study Routers entry](http://getakka.net/docs/working-with-actors/Routers)

Routers are a very important feature of Akka.NET and can be used without hassle with Remote and Cluster modules. 

## Supervision (SampleSupervision)

### Story

On a distant planet, a Jedi spots a rogue Droid. Instead of attacking him, the Jedi decides to observe it. Suddenly, something weird happens and the Droid crashes itself. Jedi senses it from far away using his special powers.

### How to run the sample

Run the project SampleSupervision. The story will unfold by itself.

### Technical explanation

Supervision is another key feature of an Akka.NET and other actor frameworks. It enables actors to monitor arbitrary Actors, so that they are notified when monitored Actor dies (or is thought to have died in case of a network partition).

In this sample, Droid and RandomJedi actors are created first. Droid tells the Jedi to watch him (HeyWatchMessage) on startup.
This fact gives RandomJedi a reference (via Sender) and he starts supervising him using Watch method.
After a while, Droid is sent (via Scheduler) a PleaseCrash message. Droid decides to grind to a halt using GracefulStop method. This method actually kills it in a way that does not cause the Droid to restart.
RandomJedi receives a Terminated system message, because he was Watching the Droid.

#### Actors

* Droid
* RandomJedi

#### Messages

* HeyWatchMe
* Terminated (system message)

### More information

[More on Supervision](http://getakka.net/docs/concepts/supervision)
