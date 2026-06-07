using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectB.Core.Supports
{

	public static class EnumeratorExtension
	{
		
		// 코루틴이 메서드 스택으로 중첩되는 경우,
		// 직접 MoveNext()와 IEnumerator.Current를 사용해서 모든 IEnumerator를 하나의 yield 흐름으로 펼쳐주는 확장 메서드임
		
		// 유니티 엔진에서는 IEnumerator가 프레임 기반이라 yield return 시 최소 한 프레임이 대기되는 문제가 있어,
		// 한 프레임 대기가 없어야 하는 경우에는 Flatten을 통해 하나의 yield 흐름으로 펼쳐서
		// Unity가 프레임에 1개의 yield return만 처리하는 문제를 해결할 수 있음
		
		public static IEnumerator Flatten(this IEnumerator enumerator)
		{
			if (enumerator == null) yield break;

			var stack = new Stack<IEnumerator>();
			stack.Push(enumerator); // 루트 enumerator를 stack에 추가

			while (stack.Count > 0)
			{
				var current = stack.Peek();

				bool movedNext = false;

				try
				{
					movedNext = current.MoveNext();
				}
				catch
				{
					// 코루틴에서 에러가 발생하면 실행 중인 모든 Enumerator를 종료
					DisposeEnumeratorStack(stack);
					throw;
				}

				if (!movedNext)
				{
					DisposeEnumerator(current);
					stack.Pop(); // 현재 Enumerator를 stack에서 제거
					continue;
				}
				
				// 다음 Enumerator가 있으면 그 Enumerator를 스택에 저장
				object yielded = current.Current;
				if (yielded is IEnumerator nestedEnumerator)
				{
					stack.Push(nestedEnumerator);
					continue;
				}

				// current.Current가 IEnumerator 아니면 WaitForSeconds, null 등의 객체일 것이므로 그대로 yield return
				yield return yielded;
			}
		}
		
		
		// Enumerator가 컴파일 후에 IDisposable로 변환될 수 있다고 함. (Finally 등의 키워드가 dispose()에 들어갈 수도 있음)
		// 그래서 IEnumerator가 끝나면 IDisposable로 변환을 시도해서 변환이 되면 Dispose()를 호출해주는 것이 안전하다고 함.
		
		static void DisposeEnumeratorStack(Stack<IEnumerator> stack)
		{
			while (stack.Count > 0)
			{
				DisposeEnumerator(stack.Pop());
			}
		}

		static void DisposeEnumerator(IEnumerator enumerator)
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

}