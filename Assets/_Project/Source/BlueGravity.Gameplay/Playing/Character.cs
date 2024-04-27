using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Gameplay.Reception;
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

        private IEventService _eventService;

        protected override void OnBegin()
        {
            base.OnBegin();

            IInputService inputService = ServiceLocator.GetService<IInputService>();
            _eventService = ServiceLocator.GetService<IEventService>();
            
            _eventService.AddEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperStartedEvent);
            _eventService.AddEventListener<InteractShopKeeperEndedEvent>(HandleInteractShopKeeperEndedEvent);
            
            _characterMovement.Begin(inputService, _characterView, _rigidBody);
            _characterInteraction.Begin(inputService, _eventService, _interactionArea);

            _characterView.Setup(_eventService);
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _eventService.RemoveEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperStartedEvent);
            _eventService.RemoveEventListener<InteractShopKeeperEndedEvent>(HandleInteractShopKeeperEndedEvent);

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

        private void HandleInteractShopKeeperStartedEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractShopKeeperStartedEvent)
            {
                _characterMovement.Stop();
                
                _characterView.Reset();
            }
        }
        
        private void HandleInteractShopKeeperEndedEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractShopKeeperEndedEvent)
            {
                _characterMovement.Begin();
            }
        }
    }
}