using System;
using BlueGravity.GameServices;

namespace BlueGravity.Input
{
    public interface IInputService : IGameService
    {
        public event Action<InputsData> OnReadInputs;
    }
}