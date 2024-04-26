using BlueGravity.Events;

namespace BlueGravity.Gameplay.Interaction
{
    public sealed class InteractionAreaExitedEvent : GameEvent
    {
        public IInteractable Interactable { get; private set; }
        public IInteractionArea InteractionArea { get; private set; }
        
        public InteractionAreaExitedEvent(IInteractable interactable, IInteractionArea interactionArea)
        {
            Interactable = interactable;
            InteractionArea = interactionArea;
        }
    }
}