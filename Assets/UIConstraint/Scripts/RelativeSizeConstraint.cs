using UnityEngine;

namespace UIConstraint
{
	
	public class RelativeSizeConstraint : UIConstraintElementBehaviour
	{
		[SerializeField] private bool _applyXSize = true;
		[SerializeField] private bool _applyYSize = true;
		[SerializeField] private Vector2 _parentDefaultSize = new Vector2(100f, 100f);
		[SerializeField] private Vector2 _myDefaultSize = new Vector2(50f, 50f);
		
		
		public override void ApplyConstraint()
		{
			tracker.Clear();
			
			if (_applyXSize)
			{
				tracker.Add(this, RectTransform, DrivenTransformProperties.SizeDeltaX);
				float size = ParentRectTransform.rect.width / _parentDefaultSize.x * _myDefaultSize.x;
				SetRectTransformSizeAxis(RectTransform.Axis.Horizontal, size);
			}
			
			if (_applyYSize)
			{
				tracker.Add(this, RectTransform, DrivenTransformProperties.SizeDeltaY);
				float size = ParentRectTransform.rect.height / _parentDefaultSize.y * _myDefaultSize.y;
				SetRectTransformSizeAxis(RectTransform.Axis.Vertical, size);
			}
		}
		
		void SetRectTransformSizeAxis(RectTransform.Axis axis, float size)
		{
			// 이 처리가 없으면 오브젝트가 삭제하기 전까지 영구적으로 Invalid AABB 에러가 발생할 수 있음
			if (float.IsNaN(size) || float.IsInfinity(size))
			{
				Debug.LogWarning("RelativeSizeConstraint에서 계산된 size가 NaN 또는 Infinity입니다.");
				size = 0f;
			}
			RectTransform.SetSizeWithCurrentAnchors(axis, size);
		}
	}

} 
