using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IConsumableItemResolver<T> where T : IConsumableItem
	{
		void OnConsume(T gainCurrencyItem, int count);
	}

}