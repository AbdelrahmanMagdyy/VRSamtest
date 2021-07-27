using UnityEngine;
using UnityEngine.SceneManagement;

namespace _ProjectFiles.Scripts.Core {
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            ApplicationResetDebug();
        }

        private static void ApplicationResetDebug() 
        {
            if (!Input.GetKey(KeyCode.R)) return;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Debug.Log("Reset Active Unity Scene: " + SceneManager.GetActiveScene().name);
        }
    }
}
