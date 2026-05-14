using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.SoldierDetailNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	public class SoldierDetailScreenPresenter : UIPresenter<SoldierDetailScreenView>
	{
		// TODO:
		// 이 클래스는 현재 병사 상세 정보 화면의 "모든 로직"을 담당하고 있음 
		// 병사 정보(_soldierData, _playerSoldierData)와 관련된 로직만 이 클래스가 담당하고
		// 정보를 바탕으로 화면을 업데이트하는 로직은 SoldierDetailScreenView가 담당하게 만들어도 됨
		
		// TODO:
		// 망했다 이 클래스 너무 방대함
		// 리팩토링 필요!!
		
		
		[SerializeField] private SoldierDatabaseInstaller _soldierDatabaseInstaller;
		[SerializeField] private SoldierDetailServicePortInstaller _soldierDetailServicePortInstaller;
		[SerializeField] private SoldierLevelUpServicePortInstaller _soldierLevelUpServicePortInstaller;

		private ISoldierData _soldierData;
		private IReadOnlyPlayerSoldier _playerSoldierData;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.LevelUpPageView.ConsumeFoodButtonClicked += OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback += OnSoldierDataUpdateCallback;
			
			SoldierDetailNavigateButtonEvents.Clicked += OnSoldierDetailNavigateButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.LevelUpPageView.ConsumeFoodButtonClicked -= OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback -= OnSoldierDataUpdateCallback;
			
			SoldierDetailNavigateButtonEvents.Clicked -= OnSoldierDetailNavigateButtonClicked;
		}

		void OnConsumeFoodButtonClicked()
		{
			_soldierLevelUpServicePortInstaller.Port.ConsumeFoods(_playerSoldierData.SoldierData);
		}

		void OnSoldierDataUpdateCallback(IReadOnlyPlayerSoldier playerSoldier)
		{
			UpdateData(playerSoldier);
		}
		
		void OnSoldierDetailNavigateButtonClicked(string pageId)
		{
			void SetActivePage(SoldierDetailPageView page)
			{
				if (pageId == page.PageId)
				{
					page.Show();
				}
				else
				{
					page.Hide();
				}
			}
			
			SetActivePage(view.InfoPageView);
			SetActivePage(view.LevelUpPageView);
		}

		void UpdateData(IReadOnlyPlayerSoldier playerSoldier)
		{
			if (_playerSoldierData != null)
			{
				UnsubscribePlayerSoldierData();
			}
			
			_playerSoldierData = playerSoldier;
			SubscribePlayerSoldierData();
			
			// 기본 업데이트
			view.SetSpiritIcon(_soldierData.Spirit);
			view.SetSoldierRoleIcon(_soldierData.Role);
			view.SetAttackTypeIcon(_soldierData.AttackType);
			view.SetPositionIcon(_soldierData.Position);
			
			
			// 정보 페이지 업데이트
			view.InfoPageView.SetLevel(playerSoldier.Level);
			view.InfoPageView.SetRank(playerSoldier.Rank);
			view.InfoPageView.SetCombatPower(playerSoldier.CombatPower);
			view.InfoPageView.SetStatus(playerSoldier.Status);
			

			// 레벨업 페이지 업데이트
			var nextStatus = _soldierLevelUpServicePortInstaller.Port.GetNextLevelStatus(playerSoldier.SoldierData);
			view.LevelUpPageView.SetStatus(_playerSoldierData.Status, nextStatus);

			view.LevelUpPageView.SetCurrentCombatPower(playerSoldier.CombatPower);
			var nextLevelCombatPower = _soldierLevelUpServicePortInstaller.Port.GetNextLevelCombatPower(playerSoldier.SoldierData);
			view.LevelUpPageView.SetNextLevelCombatPower(nextLevelCombatPower);

			view.LevelUpPageView.SetCurrentLevel(_playerSoldierData.Level);
			view.LevelUpPageView.SetCurrentExperience(_playerSoldierData.Exp);
			view.LevelUpPageView.SetTargetExperience(_soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(_playerSoldierData.Level));
			view.LevelUpPageView.SetConsumeFoodAmount(_soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(playerSoldier.SoldierData));
		}

		void SubscribePlayerSoldierData()
		{
			_playerSoldierData.RankChanged += OnPlayerSoldierRankChanged;
			_playerSoldierData.ExpChanged += OnPlayerSoldierExpChanged;
			_playerSoldierData.LevelChanged += OnPlayerSoldierLevelChanged;
			_playerSoldierData.StatusChanged += OnPlayerSoldierStatusChanged;
			_playerSoldierData.CombatPowerChanged += OnPlayerSoldierCombatPowerChanged;
		}

		void UnsubscribePlayerSoldierData()
		{
			_playerSoldierData.RankChanged -= OnPlayerSoldierRankChanged;
			_playerSoldierData.ExpChanged -= OnPlayerSoldierExpChanged;
			_playerSoldierData.LevelChanged -= OnPlayerSoldierLevelChanged;
			_playerSoldierData.StatusChanged -= OnPlayerSoldierStatusChanged;
			_playerSoldierData.CombatPowerChanged -= OnPlayerSoldierCombatPowerChanged;
		}
		
		void OnPlayerSoldierRankChanged()
		{
			view.InfoPageView.SetRank(_playerSoldierData.Rank);
		}

		void OnPlayerSoldierExpChanged()
		{
			view.LevelUpPageView.SetCurrentExperience(_playerSoldierData.Exp);
		}

		void OnPlayerSoldierLevelChanged()
		{
			view.InfoPageView.SetLevel(_playerSoldierData.Level);
			
			view.LevelUpPageView.SetCurrentLevel(_playerSoldierData.Level);
			view.LevelUpPageView.SetTargetExperience(_soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(_playerSoldierData.Level));
			
			view.LevelUpPageView.SetConsumeFoodAmount(_soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(_playerSoldierData.SoldierData));
		}

		void OnPlayerSoldierStatusChanged()
		{
			view.InfoPageView.SetStatus(_playerSoldierData.Status);
			
			var nextStatus = _soldierLevelUpServicePortInstaller.Port.GetNextLevelStatus(_playerSoldierData.SoldierData);
			view.LevelUpPageView.SetStatus(_playerSoldierData.Status, nextStatus);
		}

		void OnPlayerSoldierCombatPowerChanged()
		{
			view.InfoPageView.SetCombatPower(_playerSoldierData.CombatPower);
			
			view.LevelUpPageView.SetCurrentCombatPower(_playerSoldierData.CombatPower);
			var nextLevelCombatPower = _soldierLevelUpServicePortInstaller.Port.GetNextLevelCombatPower(_playerSoldierData.SoldierData);
			view.LevelUpPageView.SetNextLevelCombatPower(nextLevelCombatPower);
		}
	}

}