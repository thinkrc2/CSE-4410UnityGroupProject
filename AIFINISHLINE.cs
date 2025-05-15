using UnityEngine;
using UnityEngine.SceneManagement;

public class AIFinishDetectorScene : MonoBehaviour
{
    // Name of the scene to load when the AI wins (player loses).
    public string loseSceneName = "LoseScene";

    private void OnTriggerEnter(Collider other)
    {
        // If the AI reaches the finish line...
        if (other.gameObject.name == "AI")
        {
            // Load the lose scene. Ensure the scene is in Build Settings.
            SceneManager.LoadScene(loseSceneName);
        }
    }
}