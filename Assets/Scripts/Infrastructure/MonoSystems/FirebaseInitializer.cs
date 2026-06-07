using Firebase;
using UnityEngine;

namespace ProjectB.Infrastructure.MonoSystems
{

	public class FirebaseInitializer
	{
		public FirebaseInitializer()
		{
			Initialize();
		}

		void Initialize()
		{
			FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
			{
				var dependencyStatus = task.Result;
				if (dependencyStatus == DependencyStatus.Available)
				{
					// Firebase 초기화 성공
					FirebaseApp app = FirebaseApp.DefaultInstance;
					Debug.Log("Firebase 초기화 성공");
				}
				else
				{
					Debug.LogError($"Firebase 초기화 실패: {dependencyStatus}");
					// TODO: Firebase 초기화 실패 대응
				}
			});
		}
	}

}