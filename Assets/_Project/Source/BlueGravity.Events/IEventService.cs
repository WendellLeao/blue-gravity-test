using BlueGravity.GameServices;
using UnityEngine.Events;

namespace BlueGravity.Events
{
    public interface IEventService : IGameService
    {
        public void AddEventListener<T>(UnityAction<GameEvent> listener) where T : GameEvent;

        public void RemoveEventListener<T>(UnityAction<GameEvent> listener) where T : GameEvent;

        public void DispatchEvent(GameEvent gameEvent);
    }
}