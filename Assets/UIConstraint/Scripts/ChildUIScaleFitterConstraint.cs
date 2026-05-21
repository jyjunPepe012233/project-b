using UnityEngine;

namespace UIConstraint
{

	[ExecuteAlways] // 에디터에서도 콜백(OnRectTransformDimensionsChange)이 호출되도록 하는 처리
	[RequireComponent(typeof(RectTransform))]
	public class ChildUIScaleFitterConstraint : UIConstraintElementBehaviour
	{
		// true면 x, y 중 작은 scale을 기준으로 삼아 동일한 비율의 scale을 적용함
		// false면 x, y가 각각 CellSize에 맞추려고 하여 비율이 달라질 수 있음
		public bool useUniformScaling = true;
		
		public override void ApplyConstraint()
		{
			tracker.Clear();
			
			Vector2 fillSize = GetComponent<RectTransform>().rect.size;
			foreach (RectTransform child in transform)
			{
				// child의 scale을 이 컴포넌트가 제어하겠다고 tracker에 등록함
				tracker.Add(this, child, DrivenTransformProperties.Scale);
				
				// child의 실제 제어 여부에 상관 없이 child의 scale 조작을 막아놓을 것이므로 Tracker.Add 뒤에 child 활성화 여부를 체크. 
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
