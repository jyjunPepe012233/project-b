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
			Coroutine coroutine = _runner.StartCoroutine(iEnumerator);
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