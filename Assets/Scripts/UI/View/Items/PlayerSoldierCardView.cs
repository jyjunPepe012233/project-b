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
		
		private PrefabDictionary<ISoldierData> _soldierDisplayDictionary;
		private PrefabDictionary<ISoldierRoleData> _roleIconDictionary;
		private PrefabDictionary<ISpiritData> _spiritIconDictionary;

		protected override void Awake()
		{
			base.Awake();
			_soldierDisplayDictionary = new PrefabDictionary<ISoldierData>(_soldierDisplayParent, 4);
			_roleIconDictionary = new PrefabDictionary<ISoldierRoleData>(_roleIconParent, 4);
			_spiritIconDictionary = new PrefabDictionary<ISpiritData>(_spiritIconParent, 4);
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
				_soldierDisplayDictionary.RegisterAndSetActiveInstance(null, soldierDisplayPrefab);
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
				_roleIconDictionary.RegisterAndSetActiveInstance(null, roleIconPrefab);
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
				_spiritIconDictionary.RegisterAndSetActiveInstance(null, spiritIconPrefab);
			}
			else
			{
				Debug.LogError($"PlayerSoldierCardView: SpiritIconParent가 설정되지 않음. 위치: {TransformDebug.GetHierarchyPath(transform)}");
			}
		}
	}

}