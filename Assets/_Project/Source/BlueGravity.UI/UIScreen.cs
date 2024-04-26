using BlueGravity.GameServices;
using UnityEngine;

namespace BlueGravity.UI
{
    public abstract class UIScreen : MonoBehaviour, IUIScreen
    {
        private IScreenService _screenService;
        private bool _isInitialized;
        private bool _isOpened;

        public void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }
            
            _screenService = ServiceLocator.GetService<IScreenService>();
            
            _screenService.RegisterScreen(this);
            
            SetIsOpened(false);

            _isInitialized = true;
            
            OnInitialize();
        }

        public void Dispose()
        {
            if (!_isInitialized)
            {
                return;
            }

            _screenService.UnregisterScreen(this);
            
            OnDispose();

            _isInitialized = false;
        }

        public void Open()
        {
            SetIsOpened(true);
            
            OnOpen();
        }

        public void Close()
        {
            SetIsOpened(false);
            
            OnClose();
        }

        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            OnHide();
        }

        protected virtual void OnInitialize()
        { }
        
        protected virtual void OnDispose()
        { }
        
        protected virtual void OnOpen()
        { }
        
        protected virtual void OnClose()
        { }
        
        protected virtual void OnShow()
        { }
        
        protected virtual void OnHide()
        { }

        private void SetIsOpened(bool isOpened)
        {
            _isOpened = isOpened;
            
            gameObject.SetActive(_isOpened);
        }
    }
}