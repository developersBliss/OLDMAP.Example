using developersBliss.OLDMAP.Example;
using developersBliss.OLDMAP.Hosting;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder applicationBuilder = Host.CreateApplicationBuilder();
applicationBuilder.Services
	.AddOLDMAP()
	.AddMyApplication()
	.AddMyEventHandler()
	.AddMyApplicationClient()
;
IHost host = applicationBuilder.Build();
await host.RunAsync();
