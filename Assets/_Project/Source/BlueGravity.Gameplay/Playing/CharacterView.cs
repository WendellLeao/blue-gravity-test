using BlueGravity.Gameplay.Assembler;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterView : EntityView, ICharacterView
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private HumanoidAssembler _humanoidAssembler;

        private static readonly int IsIdle = Animator.StringToHash("IsIdle");
        private static readonly int HorizontalMovement = Animator.StringToHash("HorizontalMovement");
        private static readonly int VerticalMovement = Animator.StringToHash("VerticalMovement");

        private Vector2 _normalizedMovement;

        protected override void OnSetup()
        {
            base.OnSetup();

            _humanoidAssembler.Begin(_animator);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _humanoidAssembler.Stop();
        }

        public void SetNormalizedMovement(Vector2 movement)
        {
            _normalizedMovement = movement;

            bool isCharacterIdle = IsCharacterIdle(_normalizedMovement);
            
            _animator.SetBool(IsIdle, isCharacterIdle);
            
            if (isCharacterIdle)
            {
                return;
            }

            _animator.SetFloat(HorizontalMovement, _normalizedMovement.x);
            _animator.SetFloat(VerticalMovement, _normalizedMovement.y);
        }

        private bool IsCharacterIdle(Vector2 movement)
        {
            if (movement.x == 0.0f && movement.y == 0.0f)
            {
                return true;
            }

            return false;
        }
    }
}