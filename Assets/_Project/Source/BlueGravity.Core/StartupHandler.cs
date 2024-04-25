using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlueGravity.Core
{
    public sealed class StartupHandler : MonoBehaviour
    {
        private void Start()
        {
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(activeSceneIndex + 1);
        }
    }
}
