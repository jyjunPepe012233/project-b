using ProjectB.Core.Supports;
using ProjectB.UI.Views.Buttons;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Views.Items
{

	public class PlayerSoldierCardView : ButtonView
	{
		[SerializeField] protected TextMeshProUGUI _soldierNameText;
		[SerializeField] protected RectTransform _soldierDisplayParent;
		[SerializeField] protected RectTransform _roleIconParent;
		[SerializeField] protected RectTransform _spiritIconParent;
		
		private GameObject _soldierDisplayInstance;
		private GameObject _roleIconInstance;
		private GameObject _spiritIconInstance;
		
		public void SetSoldierName(string name)
		{
			if (_soldierNameText)
			{
				_soldierNameText.text = name;
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: SoldierNameText가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
		
		public void SetSoldierDisplay(GameObject soldierDisplayPrefab)
		{
			if (_soldierDisplayParent != null)
			{
				if (_soldierDisplayInstance != null)
				{
					Destroy(_soldierDisplayInstance);
				}
				_soldierDisplayInstance = Instantiate(soldierDisplayPrefab, _soldierDisplayParent, false);
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: SoldierDisplayParent가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
		
		public void SetRoleIcon(GameObject roleIconPrefab)
		{
			if (_roleIconParent != null)
			{
				if (_roleIconInstance != null)
				{
					Destroy(_roleIconInstance);
				}
				_roleIconInstance = Instantiate(roleIconPrefab, _roleIconParent, false);
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: RoleIconParent가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
		
		public void SetSpiritIcon(GameObject spiritIconPrefab)
		{
			if (_spiritIconParent != null)
			{
				if (_spiritIconInstance != null)
				{
					Destroy(_spiritIconInstance);
				}
				_spiritIconInstance = Instantiate(spiritIconPrefab, _spiritIconParent, false);
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: SpiritIconParent가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
	}

}