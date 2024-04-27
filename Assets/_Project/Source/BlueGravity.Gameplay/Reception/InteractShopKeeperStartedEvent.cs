using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class InteractShopKeeperStartedEvent : GameEvent
    {
        public IInteractionArea InteractionArea { get; private set; }

        public InteractShopKeeperStartedEvent(IInteractionArea interactionArea)
        {
            InteractionArea = interactionArea;
        }
    }
}