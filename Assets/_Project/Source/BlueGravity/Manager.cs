using UnityEngine;

namespace BlueGravity
{
    [DisallowMultipleComponent]
    public abstract class Manager : MonoBehaviour
    {
        private bool _hasInitialized;

        public void Initialize()
        {
            if (_hasInitialized)
            {
                return;
            }
            
            OnInitialize();
        }

        public void Dispose()
        {
            if (!_hasInitialized)
            {
                return;
            }
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            if (!_hasInitialized)
            {
                return;
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float deltaTime)
        {
            if (!_hasInitialized)
            {
                return;
            }
            
            OnFixedTick(deltaTime);
        }

        protected virtual void OnInitialize()
        { }
        
        protected virtual void OnDispose()
        { }
        
        protected virtual void OnTick(float deltaTime)
        { }
        
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}