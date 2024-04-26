using BlueGravity.Gameplay.Interaction;
using UnityEngine;

namespace BlueGravity.Gameplay.Reception
{
    public sealed class ShopKeeper : Interactable
    {
        protected override void OnBegin()
        {
            base.OnBegin();

            Debug.Log("Hi there! Wanna buy something cool?");
        }

        protected override void OnInteract()
        {
            base.OnInteract();

            Debug.Log("Interact ShopKeeper");
        }

        protected override void OnStopInteract()
        {
            base.OnStopInteract();
            
            Debug.Log("Stop ShopKeeper Interaction");
        }
    }
}