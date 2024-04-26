using BlueGravity.Gameplay.Interaction;
using BlueGravity.Input;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterInteraction : EntityComponent
    {
        private IInputService _inputService;
        private IInteractionArea _interactionArea;

        public void Begin(IInputService inputService, IInteractionArea interactionArea)
        {
            _inputService = inputService;
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
        
        private void HandleReadInputs(InputsData inputsData)
        {
            if (inputsData.PressInteract)
            {
                TryInteractWithAvailableInteractable();
            }
        }

        private void TryInteractWithAvailableInteractable()
        {
            if (_interactionArea.TryGetAvailableInteractableNearby(out IInteractable interactable))
            {
                interactable.TryInteract();
            }
        }
    }
}