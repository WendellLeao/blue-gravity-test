using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Input;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterInteraction : EntityComponent
    {
        private IInputService _inputService;
        private IEventService _eventService;
        private IInteractionArea _interactionArea;
        private IInteractable _interactable;
        private bool _hasInteractableNearby;

        public void Begin(IInputService inputService, IEventService eventService, IInteractionArea interactionArea)
        {
            _inputService = inputService;
            _eventService = eventService;
            _interactionArea = interactionArea;
            
            base.Begin();
        }

        protected override void OnBegin()
        {
            base.OnBegin();
                       
            _inputService.OnReadInputs += HandleReadInputs;
        }

        protected override void OnStop()
        {
            _inputService.OnReadInputs -= HandleReadInputs;
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            HandleInteractableObjectsNearby();
        }

        private void HandleReadInputs(InputsData inputsData)
        {
            if (_hasInteractableNearby && inputsData.PressInteract)
            {
                _interactable.TryInteract(_interactionArea);
            }
        }

        private void HandleInteractableObjectsNearby()
        {
            if (!_hasInteractableNearby)
            {
                if (_interactionArea.TryGetAvailableInteractableNearby(out IInteractable interactable))
                {
                    _hasInteractableNearby = true;
                    _interactable = interactable;

                    _eventService.DispatchEvent(new InteractionAreaEnteredEvent(_interactable, _interactionArea));
                }
                
                return;
            }
            
            if (!_interactionArea.TryGetAvailableInteractableNearby(out IInteractable _))
            {
                _hasInteractableNearby = false;
                _interactable = null;
                
                _eventService.DispatchEvent(new InteractionAreaExitedEvent(_interactable, _interactionArea));
            }
        }
    }
}