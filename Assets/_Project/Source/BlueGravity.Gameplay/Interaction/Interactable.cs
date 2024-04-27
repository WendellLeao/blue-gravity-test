namespace BlueGravity.Gameplay.Interaction
{
    public abstract class Interactable : EntityComponent, IInteractable
    {
        private bool _isAvailable = true;
        
        public bool IsAvailable => _isAvailable;

        public bool TryInteract(IInteractionArea interactionArea)
        {
            if (!_isAvailable)
            {
                return false;
            }

            OnInteract(interactionArea);

            _isAvailable = false;
            
            return true;
        }

        public void StopInteraction()
        {
            if (_isAvailable)
            {
                return;
            }
            
            _isAvailable = true;
            
            OnStopInteract();
        }

        protected virtual void OnInteract(IInteractionArea interactionArea)
        { }
        
        protected virtual void OnStopInteract()
        { }
    }
}