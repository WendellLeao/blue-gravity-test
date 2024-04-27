using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class InteractShopKeeperEvent : GameEvent
    {
        public IInteractionArea InteractionArea { get; private set; }

        public InteractShopKeeperEvent(IInteractionArea interactionArea)
        {
            InteractionArea = interactionArea;
        }
    }
}