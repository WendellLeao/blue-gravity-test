using BlueGravity.Gameplay.Interaction;
using UnityEngine;

namespace BlueGravity.Gameplay
{
    public sealed class ShopKeeper : Interactable
    {
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