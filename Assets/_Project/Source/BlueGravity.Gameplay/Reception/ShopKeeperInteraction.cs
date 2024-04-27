using BlueGravity.Events;
using BlueGravity.Gameplay.Interaction;
using BlueGravity.Services;
using UnityEngine;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class ShopKeeperInteraction : Interactable
    {
        private IEventService _eventService;

        protected override void OnBegin()
        {
            base.OnBegin();
            
            Debug.Log("Hi there! Do you want to buy something cool?");

            _eventService = ServiceLocator.GetService<IEventService>();
        }

        protected override void OnInteract(IInteractionArea interactionArea)
        {
            base.OnInteract(interactionArea);

            _eventService.DispatchEvent(new InteractShopKeeperEvent(interactionArea));
        }
    }
}