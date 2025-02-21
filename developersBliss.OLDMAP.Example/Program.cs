using developersBliss.OLDMAP.Example;
using developersBliss.OLDMAP.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder applicationBuilder = Host.CreateApplicationBuilder();
applicationBuilder.Services
	.AddOLDMAP()
	.AddKafkaDomainMessaging()
	.AddPostgreSqlMartenAggregateRootStorage()
	.TryAddPostgreSqlMartenAggregateRootStore<FooBar>()
	.AddApplicationServiceWithPureStyle<FooBarService, FooBar>()
	.AddTransient<MyApplicationClient>()
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
