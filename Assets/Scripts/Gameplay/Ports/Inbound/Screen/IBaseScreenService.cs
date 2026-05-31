using System;

namespace ProjectB.Gameplay.Ports.Inbound.Screen
{
	public struct ScreenServiceEvents
	{
		public event Action Open;
		public event Action Close;
		
		// 이 메서드는 BaseScreenService(IBaseScreenService의 구현체)가 사용함
		// 메서드가 readonly면 구조체의 상태를 변경하지 않는다고 컴파일러에게 알려줌. (빈번한 값 복사를 줄여 성능 최적화에 도움됨)
		public readonly void InvokeOpen() => Open?.Invoke();
		public readonly void InvokeClose() => Close?.Invoke();
	}

	public interface IBaseScreenService
	{
		ScreenServiceEvents Events { get; }
		
		void Open();
		void Close();
	}

}