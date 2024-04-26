using BlueGravity.GameServices;

namespace BlueGravity.UI
{
    public interface IScreenService : IGameService
    {
        public void RegisterScreen(IUIScreen screen);

        public void UnregisterScreen(IUIScreen screen);

        public void OpenScreen<T>(UIScreenType screenType = UIScreenType.Additive) where T : IUIScreen;

        public void CloseScreenOnTop();
    }
}
