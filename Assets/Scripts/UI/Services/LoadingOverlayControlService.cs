using System;
using System.Collections;
using AssetValidator;
using InspectorGadgets.Attributes;
using ProjectB.UI.Screens.LoadingOverlay;
using UnityEngine;

namespace ProjectB.UI.Services
{
    public class LoadingOverlayControlService : MonoBehaviour, IValidatable
    {
        [Required, SerializeField] private LoadingOverlayPresenter _loadingOverlayPresenter;
        
        public IEnumerator OpenTransition()
        {
            yield return _loadingOverlayPresenter.OpenTransition();
        }

        public IEnumerator CloseTransition()
        {
            yield return _loadingOverlayPresenter.CloseTransition();
        }

        public MonoBehaviour GetMonoBehaviour() => this;

        public ValidationMethod GetValidationMethod()
        {
            return new ValidationMethod()
                .Register("LoadingOverlayPresenter 할당", () => _loadingOverlayPresenter != null);
        }
    }
}