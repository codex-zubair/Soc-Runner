using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Add a public function that will be called when the button is pressed
    public void LoadMainScreen()
    {
        // Load the main screen scene
        SceneManager.LoadScene(1);
    }
}
