# Remote sample

## Story

Jedi Council decides to deploy Qui Gon Jinn to the peaceful planet of Naboo. Jedi commander sends a report request to Qui Gon 
and he replies that Amidala is safe.

## How to run the sample

1. Run the Naboo executable
2. Run the JediCouncil executable
3. Wait 30 seconds for the plot to unfold (observe console messages)

## Technical explanation

There are two executables that form remote link in this sample:

1. Naboo serves purely as a host for Qui Gon, who is deployed using remote deployment (does not start on Naboo when it is run)
2. JediCouncil initiates communication with Naboo, first by deploying Qui Gon ,then by telling him to report. Qui Gon responds successfuly upon request.

Remote deployment of QuiGonJinn is configured using App.Config in the JediCouncil application.
Please note that the message exchange between JediCommander and QuiGonJinn is actually done using Scheduler with indication of JediCommander as the sender.
Sender information is used by QuiGonJinn to send the response to the right actor.

The most important thing in this sample is that all Akka features work the same on Remote configuration as on the local one!

### Actors

* JediCommander
* QuiGonJinn

### Messages

* ReportToBase
* AmidalaIsSafe

## More information

Please refer to the Akka.Remote docs, especially:

[More on remote configuration](http://getakka.net/docs/remoting/#how-to-form-associations-between-remote-systems)
[Remote Actor deployment](http://getakka.net/docs/remoting/deployment)
