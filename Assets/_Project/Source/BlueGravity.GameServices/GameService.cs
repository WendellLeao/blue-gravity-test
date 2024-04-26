using UnityEngine;

namespace BlueGravity.GameServices
{
    [DisallowMultipleComponent]
    public abstract class GameService : MonoBehaviour
    {
        protected abstract void RegisterService();

        protected abstract void UnregisterService();

        public void Initialize()
        {
            RegisterService();
            
            OnInitialize();
        }

        public void Dispose()
        {
            UnregisterService();
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            OnTick(deltaTime);
        }
        
        protected virtual void OnInitialize()
        { }
        
        protected virtual void OnDispose()
        { }
        
        protected virtual void OnTick(float deltaTime)
        { }
    }
}