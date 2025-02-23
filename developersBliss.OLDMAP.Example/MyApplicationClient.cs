using developersBliss.OLDMAP.Messaging;

namespace developersBliss.OLDMAP.Example;
public class MyApplicationClient(
	IDomainMessageSender domainMessageSender,
	DomainMessagePacker domainMessagePacker
) {
	public async Task Do() {
		AggregateRootAddress myFooBar = new() {
			Domain = "MyApplication",
			AggregateRoot = "FooBar",
			AggregateRootId = Guid.NewGuid().ToString("N")
		};
		PackedDomainMessage initializeMessage = domainMessagePacker.PackMessage(
			domainMessageId: Guid.NewGuid().ToString("N"),
			address: myFooBar,
			domainMessage: new InitializeFooBar()
		);
		PackedDomainMessage incrementMessage1 = domainMessagePacker.PackMessage(
			domainMessageId: Guid.NewGuid().ToString("N"),
			address: myFooBar,
			domainMessage: new IncrementFooBar(Amount: 1)
		);
		PackedDomainMessage incrementMessage2 = domainMessagePacker.PackMessage(
			domainMessageId: Guid.NewGuid().ToString("N"),
			address: myFooBar,
			domainMessage: new IncrementFooBar(Amount: 5)
		);
		await domainMessageSender.Send(initializeMessage);
		await domainMessageSender.Send(incrementMessage1);
		await domainMessageSender.Send(incrementMessage2);
	}
}
