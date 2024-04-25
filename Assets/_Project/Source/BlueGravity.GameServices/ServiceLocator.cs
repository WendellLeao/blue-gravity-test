using System.Collections.Generic;

namespace BlueGravity.GameServices
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<int, object> ServicesDictionary = new();

        public static void RegisterService<T>(T service) where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();

            ServicesDictionary[serviceHashCode] = service;
        }

        public static void UnregisterService<T>() where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();

            ServicesDictionary.Remove(serviceHashCode);
        }

        public static T GetService<T>() where T : IGameService
        {
            int serviceHashCode = GetServiceHashCode<T>();
            
            ServicesDictionary.TryGetValue(serviceHashCode, out object service);

            return (T)service;
        }

        private static int GetServiceHashCode<T>() where T : IGameService
        {
            int serviceHashCode = typeof(T).GetHashCode();

            return serviceHashCode;
        }
    }
}
