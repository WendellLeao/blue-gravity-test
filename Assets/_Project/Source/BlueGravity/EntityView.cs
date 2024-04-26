using UnityEngine;

namespace BlueGravity
{
    [DisallowMultipleComponent]
    public abstract class EntityView : MonoBehaviour
    {
        private bool _isEnabled;

        public void Setup()
        {
            if (_isEnabled)
            {
                return;
            }
            
            _isEnabled = true;
            
            OnSetup();
        }

        public void Dispose()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _isEnabled = false;
            
            OnDispose();
        }

        public void Tick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            OnTick(deltaTime);
        }

        public void FixedTick(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            OnFixedTick(deltaTime);
        }

        protected virtual void OnSetup()
        { }
        
        protected virtual void OnDispose()
        { }
        
        protected virtual void OnTick(float deltaTime)
        { }
        
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}