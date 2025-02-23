using developersBliss.OLDMAP.Example;
using developersBliss.OLDMAP.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder applicationBuilder = Host.CreateApplicationBuilder();
applicationBuilder.Services
	.AddOLDMAP()
	.AddKafkaDomainMessageApplication()
	.AddKafkaDomainEventApplication()
	.AddPostgreSqlMartenAggregateRootStorage()
	.TryAddPostgreSqlMartenAggregateRootStore<FooBar>()
	.AddApplicationServiceWithPureStyle<FooBarService, FooBar>()
	.AddTransient<MyApplicationClient>()
	.AddDomainEventHandler<FooBarInitialized, MyEventHandler>()
	.AddDomainEventHandler<FooBarIncremented, MyEventHandler>()
;
IHost host = applicationBuilder.Build();
var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() => {
	var myApplicationClient = host.Services.GetRequiredService<MyApplicationClient>();
	Task.Run(async () => {
		await myApplicationClient.Do();
	});
});
await host.RunAsync();
