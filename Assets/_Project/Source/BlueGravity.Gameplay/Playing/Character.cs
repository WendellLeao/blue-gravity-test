using BlueGravity.GameServices;
using BlueGravity.Input;
using UnityEngine;

namespace BlueGravity.Gameplay.Playing
{
    public sealed class Character : Entity
    {
        protected override void OnBegin()
        {
            base.OnBegin();

            Debug.Log("Character has begun!");
            
            IInputService inputService = ServiceLocator.GetService<IInputService>();

            inputService.OnReadInputs += HandleReadInputs;
        }

        private void HandleReadInputs(InputsData inputsData)
        {
            Debug.Log($"Movement: {inputsData.Movement}");
        }
    }
}