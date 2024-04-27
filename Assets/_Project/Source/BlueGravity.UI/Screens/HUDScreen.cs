using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Services;
using TMPro;
using UnityEngine;

namespace BlueGravity.UI.Screens
{
    public sealed class HUDScreen : UIScreen
    {
        [SerializeField]
        private TMP_Text _promptText;

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
            if (gameEvent is InteractionAreaEnteredEvent)
            {
                SetPromptTextActive(true);
            }
        }
        
        private void HandleInteractionAreaExitedEvent(GameEvent gameEvent)
        {
            if (gameEvent is InteractionAreaExitedEvent)
            {
                SetPromptTextActive(false);
            }
        }

        private void SetPromptTextActive(bool isActive)
        {
            GameObject promptObject = _promptText.gameObject;
            
            promptObject.SetActive(isActive);
        }
    }
}