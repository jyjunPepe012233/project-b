using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ICraftEquipmentServicePort
	{
		void Craft(IEquipmentItem equipment);
	}

}