using System.Collections;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadHomeScreenPort
	{
		// =======================================================
		// 'Load' 관련 Outbound Port는 기본적으로 IEnumerator 반환 타입을 가져야 함.
		// 예를 들어 이 클래스는 IEnumerator를 반환하는 LoadHome()이라는 메서드를 포함해야 했음.
		
		// 하지만 현재 Infrastructure 로딩을 통해서만 홈 화면이 로드되고 있기 때문에 로딩 토큰(ILoadingTaskPort)를 반환하고 있음
		// 즉, 계층 간 추상화 및 의존성 역전이 이루어지지 않은 안티 패턴임
		
		// ILoadingTaskPort GetLoadingHomeTask();
		
		// 26.04.19 - 나중에 수정할 것
		// =======================================================
		// 26.05.26. 수정함. 커밋 (
		

		IEnumerator Load();

		ILoadingTask GetLoadingTask();
	}

}