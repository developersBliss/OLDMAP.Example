using developersBliss.OLDMAP.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace developersBliss.OLDMAP.Example;
public static class MyApplicationServiceCollectionExtensions {
	public static IServiceCollection AddMyApplication(this IServiceCollection services) {
		services
			.AddKafkaDomainMessageApplication(applicationName: "MyApplication")
			.AddPostgreSqlMartenAggregateRootStorage()
			.TryAddPostgreSqlMartenAggregateRootStore<FooBar>()
			.AddApplicationServiceWithPureStyle<FooBarService, FooBar>()
		;
		return services;
	}

	public static IServiceCollection AddMyEventHandler(this IServiceCollection services) {
		services
			.AddKafkaDomainEventApplication(applicationName: "MyEventHandler")
			.AddDomainEventHandler<FooBarInitialized, MyEventHandler>(applicationName: "MyEventHandler")
			.AddDomainEventHandler<FooBarIncremented, MyEventHandler>(applicationName: "MyEventHandler")
		;
		return services;
	}

	public static IServiceCollection AddMyApplicationClient(this IServiceCollection services) {
		services
			.AddHostedService<MyApplicationClient>()
			.TryAddKafkaDomainMessageSender()
		;
		return services;
	}
}
