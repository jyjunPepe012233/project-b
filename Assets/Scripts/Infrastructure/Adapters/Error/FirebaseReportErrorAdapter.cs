using Firebase.Crashlytics;
using ProjectB.Core.Types;
using ProjectB.Gameplay.Outbound.Ports.Error;
using UnityEngine;

namespace ProjectB.Infrastructure.Adapters.Error
{

	public class FirebaseReportErrorAdapter : IReportErrorPort
	{

		public void Report(ErrorData errorData)
		{
			Crashlytics.SetCustomKey("is_fatal", errorData.isFatal.ToString());

			if (errorData.exception != null)
			{
				// Exception이 있으면 그냥 Exception 자체를 저장 (type, 내부 message, stack trace 등 자동으로 포함)
				Crashlytics.LogException(errorData.exception);
				Debug.Log("Error Report함: " + errorData.message);
			}
			else
			{
				Crashlytics.Log("Exception 객체가 없는 에러 보고됨: " + errorData.message);
				Debug.Log("Error Report함 (객체 없음): " + errorData.message);
			}
		}
	}

}
