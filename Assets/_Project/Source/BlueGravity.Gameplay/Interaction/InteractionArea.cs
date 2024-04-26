using UnityEngine;

namespace BlueGravity.Gameplay.Interaction
{
    public sealed class InteractionArea : EntityComponent, IInteractionArea
    {
        [SerializeField]
        private Transform _pointTransform;
        [SerializeField]
        private float _interactionRadius = 2f;

        private readonly Collider2D[] _colliders = new Collider2D[10];

        public Transform PointTransform => _pointTransform;
        
        public bool TryGetAvailableInteractableNearby(out IInteractable interactable)
        {
            ClearCollidersArray();

            int collidersCount = Physics2D.OverlapCircleNonAlloc(_pointTransform.position, _interactionRadius, _colliders);

            for (int i = 0; i < collidersCount; i++)
            {
                Collider2D collider2d = _colliders[i];
                Transform colliderTransform = collider2d.transform;

                if (!colliderTransform.TryGetComponent(out interactable))
                {
                    continue;
                }

                if (interactable.IsAvailable)
                {
                    return true;
                }
            }

            interactable = null;
            return false;
        }

        private void ClearCollidersArray()
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                _colliders[i] = null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            
            Gizmos.DrawWireSphere(_pointTransform.position, _interactionRadius);
        }
    }
}
