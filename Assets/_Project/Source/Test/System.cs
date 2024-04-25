using UnityEngine;

namespace Test
{
    public abstract class System : MonoBehaviour
    {
        protected virtual void OnInitialize()
        { }
        
        protected virtual void OnDispose()
        { }
        
        protected virtual void OnTick(float deltaTime)
        { }
        
        protected virtual void OnFixedTick(float fixedDeltaTime)
        { }

        private void Awake()
        {
            OnInitialize();
        }

        private void OnDestroy()
        {
            OnDispose();
        }

        private void Update()
        {
            OnTick(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            OnFixedTick(Time.fixedDeltaTime);
        }
    }
}