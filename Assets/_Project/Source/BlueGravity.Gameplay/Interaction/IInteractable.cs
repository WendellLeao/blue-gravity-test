namespace BlueGravity.Gameplay.Interaction
{
    public interface IInteractable
    {
        public bool IsAvailable { get; }
        
        public bool TryInteract();

        public void StopInteraction();
    }
}