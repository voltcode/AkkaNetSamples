# Cluster sample

## Story

An imperial battleship connects with 3 tie fighters. Once they all connect (ie. form an Akka.NET cluster), 
the battleship starts sending routing commands it receives, to the fighters - turn left and right, over and over.
Not very inventive, but what would you expect from imperial soldiers.

## How to run the sample

1. Run the battleship executable
2. Run 3 instances of the tie fighter. While you run each tie fighter, observe whether the cluster has formed (nodes moving to the Up state).
3. When 3 instances of tie fighter are Up, observe that each tie fighter begins to receive turning commands (TurnLeft and TurnRight).

## Technical explanation

There are two node types that form the cluster. 

1. The battleship is the cluster's seed node. It is the node to which other nodes join.
2. Tie fighter is a non-seed node.

The cluster is configured (App.config) to require a minimum of 3 tie-fighters in addition to the battleship to be formed.

Another aspect of this sample is that routing is enabled. The battleship sits on different node than 
tie fighters and is able to route messages to them without extra hassle.

### Actors

* Battleship
* Tiefighter

### Messages

* TurnLeft
* TurnRight

## More information

Please refer to the Akka.Cluster docs, especially:

[More on cluster routing](http://getakka.net/docs/clustering/cluster-routing)
[Types of nodes in a cluster](http://getakka.net/docs/clustering/cluster-overview#nodes)
[How to set a minimum cluster size (at least 3 tie fighters)](http://getakka.net/docs/clustering/cluster-configuration#per-role-minimum-size)

To learn more about routing see LocalSamples.
