# developersBliss.OLDMAP Example

This demonstrates the usage of developersBliss.OLDMAP with a "foobar" application.

The key thing to notice is that `FooBar` and `FooBarService` contain no references to the platform. This is done in order to align with [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

The FooBar class is an Aggregate Root (called the Entity Layer in Clean Architecture) in which each instance receives Domain Messages, processes them, and then returns a corresponding Domain Event for each. The platform uses these facts to provide ACID guarantees, concurrency guarantees, ordering guarantees, and exactly-once processing guarantees. Each instance of a FooBar (with a different AggregateRootId) will be given its own partition key in Kafka and its own Marten document in PostgreSQL. The level of parallelism in your application _depends completely_ on the design of your Aggregate Roots and how many instances of each you create. You can consider these to be Actors or state machines, whichever you prefer. The point being that they are the transactional boundary of your application, meaning all transactions are encapsulated by the processing of a Domain Message by an instance of some Aggregate Root.

The FooBarService is an Application Service (called the Use Case Layer in Clean Architecture). If there are things that you'd like to do before or after your Aggregate Root processes its message, data that you'd like to grab externally, etc.; this would be the place to do it. You can keep your Aggregate Root clean while still applying all of your necessary application logic.

The platform does not require you to have an Application Service if you don't want one, but the option is there both ways. If your application is simply a bunch of Actors with no external dependencies (like in this example with the FooBar Aggregate Root), then you can replace `.AddApplicationServiceWithPureStyle<FooBarService, FooBar>()` with `.AddApplicationServiceWithAggregateRootStyle<FooBar>()`.
