using UnityEngine;

namespace UIConstraint
{
	
	public class RelativePositionConstraint : UIConstraintElementBehaviour
	{
		[SerializeField] private bool _applyXPosition = true;
		[SerializeField] private bool _applyYPosition = true;
		[SerializeField] private Vector2 _parentDefaultSize = new Vector2(100f, 100f);
		[SerializeField] private Vector2 _myDefaultPosition;
		
		
		public override void ApplyConstraint()
		{
			if (_applyXPosition)
			{
				tracker.Add(this, RectTransform, DrivenTransformProperties.AnchoredPositionX);
				float size = ParentRectTransform.rect.width / _parentDefaultSize.x * _myDefaultPosition.x;
				SetRectTransformPositionAxis(0, size);
			}
			
			if (_applyYPosition)
			{
				tracker.Add(this, RectTransform, DrivenTransformProperties.AnchoredPositionY);
				float size = ParentRectTransform.rect.height / _parentDefaultSize.y * _myDefaultPosition.y;
				SetRectTransformPositionAxis(1, size);
			}
		}
		
		// axis가 0이면 x축, 0이 아니면 y축을 제어
		void SetRectTransformPositionAxis(int axis, float position)
		{
			// 이 처리가 없으면 오브젝트가 삭제하기 전까지 영구적으로 Invalid AABB 에러가 발생할 수 있음
			if (float.IsNaN(position) || float.IsInfinity(position))
			{
				Debug.LogWarning("RelativePositionConstraint에서 계산된 position가 NaN 또는 Infinity입니다.");
				position = 0f;
			}
			RectTransform.anchoredPosition = new Vector2(
				axis == 0 ? position : RectTransform.anchoredPosition.x,
				axis == 1 ? position : RectTransform.anchoredPosition.y
			);
		}
	}

} 
