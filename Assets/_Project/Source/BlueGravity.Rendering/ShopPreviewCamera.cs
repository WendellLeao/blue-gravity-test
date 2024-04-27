using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Gameplay.Reception;
using UnityEngine;

namespace BlueGravity.Rendering
{
    public sealed class ShopPreviewCamera : Entity
    {
        private IEventService _eventService;

        public void Begin(IEventService eventService)
        {
            _eventService = eventService;
            
            base.Begin();
        }
        
        protected override void OnBegin()
        {
            base.OnBegin();
            
            _eventService.AddEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperEvent);
        }

        protected override void OnStop()
        {
            base.OnStop();
            
            _eventService.AddEventListener<InteractShopKeeperStartedEvent>(HandleInteractShopKeeperEvent);
        }

        private void HandleInteractShopKeeperEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractShopKeeperStartedEvent interactShopKeeperEvent)
            {
                IInteractionArea interactionArea = interactShopKeeperEvent.InteractionArea;

                Vector3 pointPosition = interactionArea.PointTransform.position;

                Transform currentTransform = transform;
                Vector3 currentPosition = currentTransform.position;
                
                Vector3 newPosition = new Vector3(pointPosition.x, pointPosition.y, currentPosition.z);
                
                currentTransform.position = newPosition;
            }
        }
    }
}