using System;
using BlueGravity.GameServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueGravity.Input
{
    [DisallowMultipleComponent]
    public sealed class InputService : GameService, IInputService
    {
        public event Action<InputsData> OnReadInputs;

        [Header("Inputs Objects")]
        private InputActions _inputActions;
        private InputActions.LandMapActions _landMapActions;
        private InputsData _inputsData;
        
        [Header("Inputs States")]
        private Vector2 _movement;

        public override void RegisterService()
        {
            ServiceLocator.RegisterService<IInputService>(this);
        }

        public override void UnregisterService()
        {
            ServiceLocator.UnregisterService<InputService>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            InitializeInputs();

            SubscribeEvents();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            
            _inputActions.Disable();
            
            UnsubscribeEvents();
        }

        protected override void OnTick(float deltaTime)
        {
            base.OnTick(deltaTime);

            UpdateInputsData();
            
            OnReadInputs?.Invoke(_inputsData);
        }

        private void InitializeInputs()
        {
            _inputActions = new InputActions();

            _landMapActions = _inputActions.LandMap;

            _inputActions.Enable();
        }
        
        private void SubscribeEvents()
        {
            _landMapActions.Movement.performed += HandleMovementPerformed;
        }
        
        private void UnsubscribeEvents()
        {
            _landMapActions.Movement.performed -= HandleMovementPerformed;
        }

        private void HandleMovementPerformed(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }

        private void UpdateInputsData()
        {
            _inputsData.Movement = _movement;
        }
    }
}