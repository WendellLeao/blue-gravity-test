using System;
using System.Collections.Generic;
using BlueGravity.GameServices;
using UnityEngine;
using UnityEngine.Events;

namespace BlueGravity.Events
{
    public sealed class EventService : GameService, IEventService
    {
        private readonly Dictionary<Type, UnityEvent<GameEvent>> _eventDictionary = new();

        protected override void RegisterService()
        {
            ServiceLocator.RegisterService<IEventService>(this);
        }

        protected override void UnregisterService()
        {
            ServiceLocator.UnregisterService<IEventService>();
        }

        public void AddEventListener<T>(UnityAction<GameEvent> listener) where T : GameEvent
        {
            Type type = typeof(T);

            if (_eventDictionary.TryGetValue(type, out UnityEvent<GameEvent> gameEvent))
            {
                gameEvent.AddListener(listener);
                return;
            }

            gameEvent = new UnityEvent<GameEvent>();
            
            gameEvent.AddListener(listener);
            
            _eventDictionary.Add(type, gameEvent);
        }

        public void RemoveEventListener<T>(UnityAction<GameEvent> listener) where T : GameEvent
        {
            Type type = typeof(T);

            if (!_eventDictionary.TryGetValue(type, out UnityEvent<GameEvent> gameEvent))
            {
                Debug.LogWarning($"There's no listener registered for the event '{type.Name}'");
                return;
            }

            gameEvent.RemoveListener(listener);
        }

        public void DispatchEvent(GameEvent eventToDispatch)
        {
            Type type = eventToDispatch.GetType();
            
            if (!_eventDictionary.TryGetValue(type, out UnityEvent<GameEvent> gameEvent))
            {
                Debug.LogWarning($"Couldn't dispatch the event '{type.Name}' because it wasn't registered!");
                return;
            }
            
            gameEvent.Invoke(eventToDispatch);
        }
    }
}