using ProjectB.Gameplay.Events;
using ProjectB.UI.Presenters.Buttons;
using ProjectB.UI.Views.Buttons;
using UnityEngine;
using VContainer;

namespace ProjectB.Infrastructure.UI.Buttons
{

	public class OpenMenuButtonPresenterScope : UIPresenterScope<OpenMenuButtonPresenter>
	{
		[SerializeField] private ButtonView _buttonView;
		
		[Inject] private MenuEvents _menuEvents;
		
		protected override OpenMenuButtonPresenter Compose()
		{
			return new OpenMenuButtonPresenter(_buttonView, _menuEvents);
		}
	}

}
