using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.Core.Supports
{

	public class CoroutineHandler : MonoBehaviour
	{
		private static CoroutineHandler _runner;
	
		private readonly List<Coroutine> _coroutines = new List<Coroutine>(8);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeSingleton()
		{
			if (_runner == null)
			{
				GameObject go = new GameObject(nameof(CoroutineHandler), typeof(CoroutineHandler));
				_runner = go.GetComponent<CoroutineHandler>();
				DontDestroyOnLoad(go);
			}
		}

		public static Coroutine StartAndAdd(IEnumerator iEnumerator)
		{
			// Flatten을 사용하여 중첩 Yield를 하나의 Yield 흐름으로 만듬.
			// Flatten을 사용하지 않으면 Unity는 한 프레임에 하나의 yield return만 처리하기 때문에, 중첩된 IEnumerator가 있을 경우 중첩 IEnumerator가 있을 때마다 한 프레임씩 지연될 수 있음
			// (Unity의 고질적인 문제를 해결하기 위한 조치임. 자세한 설명은 EnumeratorExtension.cs를 참조할 것)
			Coroutine coroutine = _runner.StartCoroutine(iEnumerator.Flatten());
			
			Add(coroutine);
			return coroutine;
		}
	
		public static void Add(Coroutine coroutine)
		{
			_runner._coroutines.Add(coroutine);
		}

		public static void Stop(Coroutine coroutine)
		{
			foreach (var c in _runner._coroutines)
			{
				if (coroutine == c)
				{
					_runner.StopCoroutine(c);
				}
			}
		
			_runner._coroutines.Clear();
		}
	}

}