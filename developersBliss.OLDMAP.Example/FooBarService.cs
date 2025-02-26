namespace developersBliss.OLDMAP.Example;
public class FooBarService {
	public async Task<(FooBar, FooBarInitialized)> InitializeFooBar(
		InitializeFooBar domainMessage
	) {
		var (fooBar, domainEvent) = FooBar.InitializeFooBar(domainMessage);
		return (fooBar, domainEvent);
	}

	public async Task<(FooBar, FooBarIncremented)> IncrementFooBar(
		FooBar fooBar,
		IncrementFooBar domainMessage
	) {
		var domainEvent = fooBar.IncrementFooBar(domainMessage);
		return (fooBar, domainEvent);
	}
}
