using UnityEngine;

namespace BlueGravity
{
    public abstract class Entity : MonoBehaviour
    {
        private bool _isEnabled;

        public void Begin()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;
            
            OnBegin();
        }

        public void Stop()
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _isEnabled = false;
            
            OnStop();
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

        protected virtual void OnBegin()
        { }
        
        protected virtual void OnStop()
        { }
        
        protected virtual void OnTick(float deltaTime)
        { }
        
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }
    }
}