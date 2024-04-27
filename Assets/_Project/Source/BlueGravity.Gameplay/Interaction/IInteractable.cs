namespace BlueGravity.Gameplay.Interaction
{
    public interface IInteractable
    {
        public bool IsAvailable { get; }

        public bool TryInteract(IInteractionArea interactionArea);

        public void StopInteraction();
    }
}