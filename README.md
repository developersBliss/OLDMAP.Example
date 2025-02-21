# developersBliss.OLDMAP Example

This demonstrates the usage of developersBliss.OLDMAP with a "foobar" application.

The key thing to notice is that the FooBar and the FooBarService contain no references to the platform.

The FooBar class is an Aggregate Root. The platform uses this fact to provide ACID guarantees, concurrency guarantees, ordering guarantees, and exactly-once processing guarantees. Each instance of a FooBar (with a different AggregateRootId) will be given its own partition key in Kafka and its own Marten document in PostgreSQL. The level of parallelism in your application _depends completely_ on the design of your Aggregate Roots how many instances you create.

The FooBarService is an Application Service. If there are things that you'd like to do before or after your Aggregate Root processes its message, data that you'd like to grab externally, etc.; this would be the place to do it. You can keep your Aggregate Root clean while still applying all of your necessary application logic.
