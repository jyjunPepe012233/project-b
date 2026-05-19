using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Systems
{

	[ExecuteAlways] // 에디터에서도 콜백(OnRectTransformDimensionsChange)이 호출되도록 하는 처리
	[RequireComponent(typeof(RectTransform))]
	public class ChildUIScaleFitter : MonoBehaviour
	{
		// true면 x, y 중 작은 scale을 기준으로 삼아 동일한 비율의 scale을 적용함
		// false면 x, y가 각각 CellSize에 맞추려고 하여 비율이 달라질 수 있음
		public bool useUniformScaling = true;
		
		// 오브젝트가 활성화될 때 업데이트
		void OnEnable()
		{
			ApplySize();
		}
		
		// 자식 오브젝트 구조가 바뀔 때 업데이트
		void OnTransformChildrenChanged()
		{
			ApplySize();
		}
		
		// RectTransform의 크기가 바뀔 때 업데이트
		void OnRectTransformDimensionsChange()
		{
			ApplySize();
		}

		void ApplySize()
		{
			Vector2 fillSize = GetComponent<RectTransform>().rect.size;
			foreach (RectTransform child in transform)
			{
				if (!child.gameObject.activeSelf) continue;

				Vector2 originalSize = child.sizeDelta;

				// fillSize에 요소를 알맞게 맞추기 위한 scale을 계산
				float scaleX = fillSize.x / originalSize.x;
				float scaleY = fillSize.y / originalSize.y;

				if (useUniformScaling)
				{
					float uniformScale = Mathf.Min(scaleX, scaleY);
					child.localScale = Vector3.one * uniformScale;
				}
				else
				{
					child.localScale = new Vector3(scaleX, scaleY, 1f);
				}
			}
		}
	}

}