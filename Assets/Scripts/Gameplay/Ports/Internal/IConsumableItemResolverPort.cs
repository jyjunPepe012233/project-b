using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IConsumableItemResolverPort<T> where T : IConsumableItem
	{
		void OnConsume(T gainCurrencyItem, int count);
	}

}