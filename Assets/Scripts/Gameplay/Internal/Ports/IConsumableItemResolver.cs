using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Internal.Ports
{

	public interface IConsumableItemResolver<T> where T : IConsumableItem
	{
		void OnConsume(T gainCurrencyItem, int count);
	}

}