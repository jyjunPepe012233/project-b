namespace ProjectB.Gameplay.Inbound.Ports.Screen
{
	// BaseScreenService를 상속받지 않는 이유:
	//   BaseScreenService는 화면을 열고 닫는 기능을 제공하는 추상 클래스인데, TitleScreenManager는
	//   화면을 열고 닫는 기능이 필요 없으므로 상속받지 않음

	public interface ITitleScreenManager
	{
		void Touched();
	}

}