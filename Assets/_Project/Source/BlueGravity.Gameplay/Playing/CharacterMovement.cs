using BlueGravity.Input;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class CharacterMovement : EntityComponent
    {
        [SerializeField]
        private float _movementSpeed;

        private IInputService _inputService;
        private ICharacterView _characterView;
        private Rigidbody2D _rigidBody;
        private Vector2 _normalizedMovement;

        public void Begin(IInputService inputService, ICharacterView characterView, Rigidbody2D rigidBody)
        {
            _inputService = inputService;
            _characterView = characterView;
            _rigidBody = rigidBody;

            base.Begin();
        }
        
        protected override void OnBegin()
        {
            base.OnBegin();
                       
            _inputService.OnReadInputs += HandleReadInputs;
        }

        protected override void OnStop()
        {
            _inputService.OnReadInputs -= HandleReadInputs;
        }

        protected override void OnFixedTick(float fixedDeltaTime)
        {
            base.OnFixedTick(fixedDeltaTime);

            HandleVelocity();
        }

        private void HandleReadInputs(InputsData inputsData)
        {
            _normalizedMovement = inputsData.Movement.normalized;
        }
        
        private void HandleVelocity()
        {
            _characterView.SetNormalizedMovement(_normalizedMovement);
            
            _rigidBody.velocity = _normalizedMovement * _movementSpeed;
        }
    }
}