using System;
using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Gameplay.Ports.Outbound.Error;
using UnityEngine;

namespace ProjectB.Infrastructure.Implements.Error
{
	// 로그로 보고된 에러는 Exception 객체가 없으므로 사용하는 더미 클래스
	public class CustomLogWrapperException : Exception
	{
	}
	
	

	public class CatchUncaughtErrorAdapter : ICatchUncaughtErrorPort, IDisposable
	{
		public event Action<ErrorData> UncaughtErrorCaught;
		
		private readonly Dictionary<ulong, DateTime> _recentErrorHashes = new(); // hash, time 

		public CatchUncaughtErrorAdapter()
		{
			Application.logMessageReceived += OnLogMessageReceived;
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
		}
		
		public void Dispose()
		{
			Application.logMessageReceived -= OnLogMessageReceived;
			AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;
		}

		// Log에서 캐치할 수 있는 에러나 예외는 이 메서드에서 처리
		private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
		{
			// Unhanlded Exception이 발생하면 OnUnhandledException이 호출되고,
			// 그 이후에 LogError도 호출되는 경우가 있긴 함. 그래도 마땅한 방법이 없어서 일단 그정도 중복은 감수하기로 함.
			
			if (type == LogType.Error || type == LogType.Exception)
			{
				if (string.IsNullOrEmpty(condition))
				{
					condition = "No Condition!!!"; // 느낌표 3개는 이 코드에서 null로 판정이 났음을 식별하기 위함임
				}
				
				if (string.IsNullOrEmpty(stackTrace))
				{
					stackTrace = "No Stack Trace!!!";
				}
				
				if (!VerifyDuplicatedError(condition + stackTrace))
				{
					return; // 중복이므로 보고하지 않음
				}

				UncaughtErrorCaught?.Invoke(new ErrorData(
					new CustomLogWrapperException(),
					condition,
					stackTrace,
					isFatal: type == LogType.Exception)); // LogType.Exception은 기능에 영향을 줄 수 있는 에러로 간주함
			}
		}

		// Unhandled 예외는 이 메서드가 처리
		private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			var exception = e.ExceptionObject as Exception;

			string message = exception?.Message ?? "No Exception Message!!!"; // 느낌표 3개는 이 코드에서 null로 판정이 났음을 식별하기 위함임
			string stackTrace = exception?.StackTrace ?? "No Stack Trace!!!";
			
			if (!VerifyDuplicatedError(message + stackTrace))
			{
				return; // 중복이므로 보고하지 않음
			}
			
			UncaughtErrorCaught?.Invoke(new ErrorData(
				exception,
				message,
				stackTrace,
				isFatal: e.IsTerminating)); // IsTerminating이 true면 앱이 종료될 정도로 심각한 예외로 간주
		}

		bool VerifyDuplicatedError(string data)
		{
			ulong hash = 14695981039346656037UL;
			foreach (char c in data)
			{
				hash ^= c;
				hash *= 1099511628211;
			}

			// LogError는 중복으로 많이 찍힐 수 있으므로
			// Hash 비교를 통해 최근에 동일한 에러가 발생했는지 체크해서 중복 보고 방지
			if (_recentErrorHashes.TryGetValue(hash, out DateTime lastTime))
			{
				// 0.1초 이내에 동일한 에러가 발생했으면 중복으로 간주하고 보고하지 않음
				// 0.1초마다 주기적으로 보고
				if ((DateTime.UtcNow - lastTime).TotalMilliseconds < 100) 
				{
					return false;
				}
			}
			
			// 최근에 동일한 에러가 없거나, 0.1초 이상 지났으면 보고하고 해시 저장
			_recentErrorHashes[hash] = DateTime.UtcNow;
			return true;
		}
	}

}
