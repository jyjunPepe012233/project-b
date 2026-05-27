using InspectorGadgets.Attributes;
using ProjectB.Dependency.Installers;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.HomeScreenNavigationButton
{

	public class HomeScreenNavigationButton : UIPresenter<ButtonView>
	{
		[SerializeField] private ControlType _controlType;
		[SerializeField] private ScreenType _screenType;
		[Required, SerializeField] private HomeScreenServicePortInstaller _homeScreenServicePort;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ButtonClicked -= OnButtonClicked;
		}

		void OnButtonClicked()
		{
			if (_controlType == ControlType.Close)
			{
				CloseScreen();
			}
			else
			{
				OpenScreen();
			}
			
			
		}

		void OpenScreen()
		{
			switch (_screenType)
			{
				case ScreenType.Summon:
					_homeScreenServicePort.Port.OpenSummonScreen();
					break;
				case ScreenType.Shop:
					_homeScreenServicePort.Port.OpenShopScreen();
					break;
				case ScreenType.SoldierList:
					_homeScreenServicePort.Port.OpenSoldierListScreen();
					break;
				case ScreenType.WorldMap:
					_homeScreenServicePort.Port.OpenWorldMapScreen();
					break;
			}
		}

		void CloseScreen()
		{
			switch (_screenType)
			{
				case ScreenType.Summon:
					_homeScreenServicePort.Port.CloseSummonScreen();
					break;
				case ScreenType.Shop:
					_homeScreenServicePort.Port.CloseShopScreen();
					break;
				case ScreenType.SoldierList:
					_homeScreenServicePort.Port.CloseSoldierListScreen();
					break;
				case ScreenType.WorldMap:
					_homeScreenServicePort.Port.CloseWorldMapScreen();
					break;
			}
		}


		private enum ControlType
		{
			Open,
			Close
		}

		private enum ScreenType
		{
			Summon,
			Shop,
			SoldierList,
			WorldMap
		}
	}

}