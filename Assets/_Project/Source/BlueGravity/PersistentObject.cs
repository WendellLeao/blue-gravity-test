using UnityEngine;

namespace BlueGravity
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
