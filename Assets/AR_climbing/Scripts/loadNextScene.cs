using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextScene : MonoBehaviour
{
    // Function to load the next scene by name
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}