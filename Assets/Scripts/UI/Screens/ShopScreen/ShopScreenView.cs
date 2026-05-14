using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.Shop;
using ProjectB.UI.Buttons.ShopPageNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Screens.ShopScreen
{

	[Serializable]
	public class ShopScreenView : UIView
	{
		[Header("Shop Page Navigation Buttons")]
		[SerializeField] private ShopPageNavigateButtonComponent _shopPageNavigateButtonPrefab;
		[SerializeField] private Transform _buttonParent;
		
		[Header("Shop Page")]
		[SerializeField] private ShopPageView _shopPageViewPrefab;
		[SerializeField] private Transform _shopPageParent;

		private readonly List<ShopPageNavigateButtonComponent> _buttonInstances = new();
		private readonly List<(ShopPageView pageView, IShopPage pageData)> _shopPageInstances = new();
		
		public void InitializeNavigationButtons(IEnumerable<IShopPage> shopPages)
		{
			foreach (var buttonInstance in _buttonInstances)
			{
				Object.Destroy(buttonInstance.gameObject);
			}
			_buttonInstances.Clear();
			
			foreach (var pageData in shopPages)
			{
				var buttonInstance = Object.Instantiate(_shopPageNavigateButtonPrefab, _buttonParent);
				buttonInstance.InitializeNavigation(pageData);
				_buttonInstances.Add(buttonInstance);
			}
		}

		public void InitializeShopPages(IEnumerable<IShopPage> shopPageData)
		{ 
			foreach (var pageInstance in _shopPageInstances)
			{
				Object.Destroy(pageInstance.pageView.gameObject);
			}
			_shopPageInstances.Clear();
			
			foreach (var pageData in shopPageData)
			{
				var pageView = Object.Instantiate(_shopPageViewPrefab, _shopPageParent);
				
				pageView.SetPageName(pageData.ShopPageName);
				pageView.InitializeAllItems(pageData.ShopItems);
				
				_shopPageInstances.Add((pageView, pageData));
			}
		}

		public void OpenPage(IShopPage targetPage)
		{
			foreach (var (pageView, pageData) in _shopPageInstances)
			{
				pageView.gameObject.SetActive(pageData == targetPage);
			}
		}
	}

}