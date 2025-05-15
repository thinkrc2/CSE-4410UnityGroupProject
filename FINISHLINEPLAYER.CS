using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for scene loading

public class PlayerFinishDetectorScene : MonoBehaviour
{
    // Name of the scene to load when the player wins (set this in the Inspector).
    public string winSceneName = "WinScene";

    private void OnTriggerEnter(Collider other)
    {
        // If the Player reaches the finish line...
        if (other.gameObject.name == "Player")
        {
            // Load the win scene. Make sure the scene name is added to Build Settings.
            SceneManager.LoadScene(winSceneName);
        }
    }
}