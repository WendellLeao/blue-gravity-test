using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Input;
using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class Character : Entity
    {
        [SerializeField]
        private Rigidbody2D _rigidBody;
        [SerializeField]
        private CharacterMovement _characterMovement;
        [SerializeField]
        private CharacterInteraction _characterInteraction;
        [SerializeField]
        private InteractionArea _interactionArea;
        [SerializeField]
        private CharacterView _characterView;
        
        protected override void OnBegin()
        {
            base.OnBegin();

            IInputService inputService = ServiceLocator.GetService<IInputService>();
            IEventService eventService = ServiceLocator.GetService<IEventService>();
            
            _characterMovement.Begin(inputService, _characterView, _rigidBody);
            _characterInteraction.Begin(inputService, eventService, _interactionArea);
            
            _characterView.Setup(eventService);
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
            _characterInteraction.Tick(deltaTime);
            
            _characterView.Tick(deltaTime);
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);
            
            _characterMovement.FixedTick(fixedDeltaTime);
        }
    }
}