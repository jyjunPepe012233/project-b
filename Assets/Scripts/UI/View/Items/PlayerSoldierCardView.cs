using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Spirit;
using ProjectB.UI.Collections;
using ProjectB.UI.View.Buttons;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.View.Items
{

	public class PlayerSoldierCardView : ButtonView
	{
		[SerializeField] protected TextMeshProUGUI _soldierNameText;
		[SerializeField] protected RectTransform _soldierDisplayParent;
		[SerializeField] protected RectTransform _roleIconParent;
		[SerializeField] protected RectTransform _spiritIconParent;
		
		// 아래 3개 변수는 런타임 중에 초기화되므로 하므로 **내부에서도 프로퍼티를 통해서만 접근할 것**
		private PrefabDictionary<ISoldierData> _soldierDisplayDictionary;
		private PrefabDictionary<ISoldierRoleData> _roleIconDictionary;
		private PrefabDictionary<ISpiritData> _spiritIconDictionary;

		protected PrefabDictionary<ISoldierData> SoldierDisplayDictionary
		{
			get
			{
				if (_soldierDisplayDictionary == null)
				{
					_soldierDisplayDictionary = new PrefabDictionary<ISoldierData>(_soldierDisplayParent, 4);
				}
				return _soldierDisplayDictionary;
			}
		}
		
		protected PrefabDictionary<ISoldierRoleData> RoleIconDictionary
		{
			get
			{
				if (_roleIconDictionary == null)
				{
					_roleIconDictionary = new PrefabDictionary<ISoldierRoleData>(_roleIconParent, 4);
				}
				return _roleIconDictionary;
			}
		}
		
		protected PrefabDictionary<ISpiritData> SpiritIconDictionary
		{
			get
			{
				if (_spiritIconDictionary == null)
				{
					_spiritIconDictionary = new PrefabDictionary<ISpiritData>(_spiritIconParent, 4);
				}
				return _spiritIconDictionary;
			}
		}
		
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
				SoldierDisplayDictionary.RegisterAndSetActiveInstance(null, soldierDisplayPrefab);
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
				RoleIconDictionary.RegisterAndSetActiveInstance(null, roleIconPrefab);
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
				SpiritIconDictionary.RegisterAndSetActiveInstance(null, spiritIconPrefab);
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: SpiritIconParent가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
	}

}