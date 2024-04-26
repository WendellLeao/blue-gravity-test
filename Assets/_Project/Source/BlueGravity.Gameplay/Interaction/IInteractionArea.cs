using UnityEngine;

namespace BlueGravity.Gameplay.Interaction
{
    public interface IInteractionArea
    {
        public Transform PointTransform { get; }
        
        public bool TryGetAvailableInteractableNearby(out IInteractable interactable);
    }
}