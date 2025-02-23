using developersBliss.OLDMAP.Messaging;
using Microsoft.Extensions.Logging;

namespace developersBliss.OLDMAP.Example;
public class MyEventHandler(ILogger<MyEventHandler> logger) :
	IDomainEventHandler<FooBarInitialized>,
	IDomainEventHandler<FooBarIncremented> {
	public Task Handle(DomainEvent<FooBarInitialized> domainEvent) {
		logger.LogInformation(
			"{DomainMessageId} | Handling FooBarInitialized |",
			domainEvent.DomainMessageId
		);
		return Task.CompletedTask;
	}

	public Task Handle(DomainEvent<FooBarIncremented> domainEvent) {
		logger.LogInformation(
			"{DomainMessageId} | Handling FooBarIncremented |",
			domainEvent.DomainMessageId
		);
		return Task.CompletedTask;
	}
}
