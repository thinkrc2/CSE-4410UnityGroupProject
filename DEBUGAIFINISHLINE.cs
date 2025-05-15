using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishAI : MonoBehaviour
{
    public string loseSceneName = "LoseScene"; // Make sure this matches your actual scene name

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger: " + other.name); // For testing

        if (other.gameObject.name == "AI")
        {
            Debug.Log("AI triggered lose condition"); // Confirm this line logs
            SceneManager.LoadScene(loseSceneName);
        }
    }
}