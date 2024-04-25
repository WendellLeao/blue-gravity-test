using UnityEngine;

namespace Test
{
    public sealed class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(null);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
