namespace developersBliss.OLDMAP.Example;
public class FooBarService {
	public async Task<(FooBar, FooBarInitialized)> InitializeFooBar(
		InitializeFooBar message
	) {
		var (fooBar, result) = FooBar.InitializeFooBar(message);
		return (fooBar, result);
	}

	public async Task<(FooBar, FooBarIncremented)> IncrementFooBar(
		FooBar fooBar,
		IncrementFooBar message
	) {
		var result = fooBar.IncrementFooBar(message);
		return (fooBar, result);
	}
}
