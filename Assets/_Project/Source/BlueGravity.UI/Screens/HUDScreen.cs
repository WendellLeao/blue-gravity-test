using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.GameServices;
using TMPro;
using UnityEngine;

namespace BlueGravity.UI.Screens
{
    public sealed class HUDScreen : UIScreen
    {
        [SerializeField]
        private TMP_Text _promptText;
        [SerializeField]
        private Vector3 _promptTextOffset;

        private IEventService _eventService;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            _eventService = ServiceLocator.GetService<IEventService>();
            
            SetPromptTextActive(false);
        }

        protected override void OnSubscribeEvents()
        {
            base.OnSubscribeEvents();
            
            _eventService.AddEventListener<InteractionAreaEnteredEvent>(HandleInteractionAreaEnteredEvent);
            _eventService.AddEventListener<InteractionAreaExitedEvent>(HandleInteractionAreaExitedEvent);
        }

        protected override void OnUnsubscribeEvents()
        {
            base.OnUnsubscribeEvents();
            
            _eventService.RemoveEventListener<InteractionAreaEnteredEvent>(HandleInteractionAreaEnteredEvent);
            _eventService.AddEventListener<InteractionAreaExitedEvent>(HandleInteractionAreaExitedEvent);
        }
        
        private void HandleInteractionAreaEnteredEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractionAreaEnteredEvent interactionAreaEnteredEvent)
            {
                SetPromptTextActive(true);

                IInteractionArea interactionArea = interactionAreaEnteredEvent.InteractionArea;

                SetPromptTextPosition(interactionArea.PointTransform);
            }
        }
        
        private void HandleInteractionAreaExitedEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractionAreaExitedEvent interactionAreaExitedEvent)
            {
                SetPromptTextActive(false);
                
                IInteractionArea interactionArea = interactionAreaExitedEvent.InteractionArea;

                SetPromptTextPosition(interactionArea.PointTransform);
            }
        }

        private void SetPromptTextActive(bool isActive)
        {
            GameObject promptObject = _promptText.gameObject;
            
            promptObject.SetActive(isActive);
        }

        private void SetPromptTextPosition(Transform targetTransform)
        {
            Transform promptTransform = _promptText.transform;

            // TODO: fix this camera call
            Vector3 targetScreenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
            
            Vector3 newPosition = new Vector3(
                targetScreenPosition.x + _promptTextOffset.x, 
                targetScreenPosition.y + _promptTextOffset.y,
                targetScreenPosition.z + _promptTextOffset.z);

            promptTransform.position = newPosition;
        }
    }
}