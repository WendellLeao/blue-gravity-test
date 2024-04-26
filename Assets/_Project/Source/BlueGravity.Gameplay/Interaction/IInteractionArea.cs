namespace BlueGravity.Gameplay.Interaction
{
    public interface IInteractionArea
    {
        public bool TryGetAvailableInteractableNearby(out IInteractable interactable);
    }
}