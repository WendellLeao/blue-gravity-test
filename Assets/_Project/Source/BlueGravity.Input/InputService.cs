using System;
using BlueGravity.GameServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueGravity.Input
{
    public sealed class InputService : GameService, IInputService
    {
        public event Action<InputsData> OnReadInputs;

        [Header("Inputs Objects")]
        private InputActions _inputActions;
        private InputActions.LandMapActions _landMapActions;
        private InputsData _inputsData;
        
        [Header("Inputs States")]
        private Vector2 _movement;
        private bool _pressInteract;

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IInputService>(this);
        }

        protected override void UnregisterService()
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

            ResetInputs();
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

            _landMapActions.Interact.performed += HandleInteractPerformed;
            _landMapActions.Interact.canceled += HandleInteractCanceled;
        }
        
        private void UnsubscribeEvents()
        {
            _landMapActions.Movement.performed -= HandleMovementPerformed;
            
            _landMapActions.Interact.performed -= HandleInteractPerformed;
            _landMapActions.Interact.canceled -= HandleInteractCanceled;
        }

        private void HandleMovementPerformed(InputAction.CallbackContext context)
        {
            _movement = context.ReadValue<Vector2>();
        }

        private void HandleInteractPerformed(InputAction.CallbackContext context)
        {
            _pressInteract = true;
        }
        
        private void HandleInteractCanceled(InputAction.CallbackContext context)
        {
            _pressInteract = false;
        }
        
        private void UpdateInputsData()
        {
            _inputsData.Movement = _movement;
            _inputsData.PressInteract = _pressInteract;
        }

        private void ResetInputs()
        {
            _pressInteract = false;
        }
    }
}