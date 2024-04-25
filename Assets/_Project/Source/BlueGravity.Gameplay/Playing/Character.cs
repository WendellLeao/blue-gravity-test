using BlueGravity.GameServices;
using BlueGravity.Input;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class Character : Entity
    {
        [SerializeField]
        private CharacterMovement _characterMovement;
        [SerializeField]
        private Rigidbody2D _rigidBody;
        [SerializeField]
        private CharacterView _characterView;
        
        protected override void OnBegin()
        {
            base.OnBegin();

            IInputService inputService = ServiceLocator.GetService<IInputService>();
            
            _characterMovement.Begin(inputService, _characterView, _rigidBody);
            
            _characterView.Setup();
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _characterMovement.Stop();
            
            _characterView.Dispose();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            _characterMovement.Tick(deltaTime);
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            _characterMovement.FixedTick(fixedDeltaTime);
        }
    }
}