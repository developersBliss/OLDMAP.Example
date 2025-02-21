namespace developersBliss.OLDMAP.Example;
public class FooBar {
	public int Count { get; private set; }

	public FooBar(int count) {
		Count = count;
	}

	public static (FooBar, FooBarInitialized) InitializeFooBar(InitializeFooBar message) {
		var fooBar = new FooBar(0);
		return (fooBar, new FooBarInitialized(fooBar.Count));
	}

	public FooBarIncremented IncrementFooBar(IncrementFooBar message) {
		var previousCount = Count;
		Count += message.Amount;
		return new FooBarIncremented(previousCount, NewCount: Count);
	}
}

public record InitializeFooBar();
public record FooBarInitialized(int Count);
public record IncrementFooBar(int Amount);
public record FooBarIncremented(int PreviousCount, int NewCount);
