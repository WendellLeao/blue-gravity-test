namespace BlueGravity.Gameplay.Interaction
{
    public abstract class Interactable : Entity, IInteractable
    {
        private bool _isAvailable = true;
        
        public bool IsAvailable => _isAvailable;

        public bool TryInteract()
        {
            if (!_isAvailable)
            {
                return false;
            }

            OnInteract();

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

        protected virtual void OnInteract()
        { }
        
        protected virtual void OnStopInteract()
        { }
    }
}