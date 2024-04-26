using UnityEngine;

namespace BlueGravity
{
    [DisallowMultipleComponent]
    public abstract class Manager : MonoBehaviour
    {
        private bool _isInitialized;

        public void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }
            
            _isInitialized = true;
            
            OnInitialize();
        }

        public void Dispose()
        {
            if (!_isInitialized)
            {
                return;
            }
            
            _isInitialized = false;
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            if (!_isInitialized)
            {
                return;
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float deltaTime)
        {
            if (!_isInitialized)
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