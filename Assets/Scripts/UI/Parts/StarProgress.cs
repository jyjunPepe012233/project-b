using UnityEngine;

namespace ProjectB.UI.Parts
{

	public class StarProgress : MonoBehaviour
	{
		[SerializeField] private StarProgressItem[] _stars;
		
		public void SetStarCount(byte starCount)
		{
			for (int i = 0; i < _stars.Length; i++)
			{
				_stars[i].SetEnabled(i < starCount);
			}
		}
	}

}