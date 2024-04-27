using System;
using BlueGravity.Services;

namespace BlueGravity.Input
{
    public interface IInputService : IGameService
    {
        public event Action<InputsData> OnReadInputs;
    }
}