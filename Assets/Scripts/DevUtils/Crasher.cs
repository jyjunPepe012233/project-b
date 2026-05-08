using System;
using UnityEngine;

namespace ProjectB
{

	public class Crasher : MonoBehaviour
	{
		public void Crash()
		{
			Recursive(0);
		}

		void Recursive(int x)
		{
			Recursive(x);
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				throw new Exception("Test Exception by Crasher");
			}
		}
	}

}