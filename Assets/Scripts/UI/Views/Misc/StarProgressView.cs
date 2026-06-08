using ProjectB.UI.Core;
using ProjectB.UI.Views.Items;
using UnityEngine;

namespace ProjectB.UI.Views.Misc
{

	public class StarProgressView : UIView
	{
		[SerializeField] private StarView[] _stars;  
			
		public void SetStarCount(int starCount)
		{
			for (int i = 0; i < _stars.Length; i++)
			{
				_stars[i].SetStarActive(i < starCount);
			}
		}
	}

}