using System.Collections.Generic;
using BlueGravity.Services;
using BlueGravity.Utilities.Extensions;
using UnityEngine;

namespace BlueGravity.UI
{
    public sealed class ScreenService : GameService, IScreenService
    {
        private readonly List<IUIScreen> _registeredScreens = new();
        private readonly List<IUIScreen> _openedScreens = new();

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IScreenService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IScreenService>();
        }

        public void RegisterScreen(IUIScreen screen)
        {
            if (_registeredScreens.Contains(screen))
            {
                Debug.LogWarning($"The screen '{screen.GetType().Name}' is already registered!");
                return;
            }

            _registeredScreens.Add(screen);
        }

        public void UnregisterScreen(IUIScreen screen)
        {
            if (!_registeredScreens.Contains(screen))
            {
                Debug.LogWarning($"The screen '{screen.GetType().Name}' wasn't registered!");
                return;
            }

            _registeredScreens.Remove(screen);
        }

        public void OpenScreen<T>(UIScreenType screenType = UIScreenType.Additive) where T : IUIScreen
        {
            if (TryGetRegisteredScreen<T>(out IUIScreen screen))
            {
                if (_openedScreens.Contains(screen))
                {
                    Debug.LogWarning($"The screen '{typeof(T).Name}' is already opened!");
                    return;
                }
                
                OpenScreen(screen, screenType);
            }
        }

        public void CloseScreenOnTop()
        {
            if (_openedScreens.TryGetLast(out IUIScreen screen))
            {
                screen.Close();
            }

            _openedScreens.Remove(screen);
        
            if (_openedScreens.TryGetLast(out screen))
            {
                screen.Show();
            }
        }

        private void OpenScreen(IUIScreen screen, UIScreenType screenType)
        {
            if (screenType == UIScreenType.Single)
            {
                HideScreenOnTop();
            }
            
            screen.Open();
            
            _openedScreens.Add(screen);
        }

        private void HideScreenOnTop()
        {
            if (_openedScreens.TryGetLast(out IUIScreen screen))
            {
                screen.Hide();
            }
        }
        
        private bool TryGetRegisteredScreen<T>(out IUIScreen screen)
        {
            foreach (IUIScreen registeredScreen in _registeredScreens)
            {
                if (registeredScreen is T)
                {
                    screen = registeredScreen;
                    return true;
                }
            }

            Debug.LogError($"There's no registered screen with name '{typeof(T).Name}'");
            
            screen = null;
            return false;
        }
    }
}