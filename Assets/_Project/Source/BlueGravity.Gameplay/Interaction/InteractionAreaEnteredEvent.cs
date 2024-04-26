using BlueGravity.Events;

namespace BlueGravity.Gameplay.Interaction
{
    public sealed class InteractionAreaEnteredEvent : GameEvent
    {
        public IInteractable Interactable { get; private set; }
        public IInteractionArea InteractionArea { get; private set; }

        public InteractionAreaEnteredEvent(IInteractable interactable, IInteractionArea interactionArea)
        {
            Interactable = interactable;
            InteractionArea = interactionArea;
        }
    }
}
