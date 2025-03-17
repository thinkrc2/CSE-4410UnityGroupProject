using UnityEngine;

public class FinishLine : MonoBehaviour
{
    //need to create as a game object
    public ConditionsManager conditionsManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.PlayerWins();
        }
        else if (other.CompareTag("AI"))
        {
            gameManager.AIWins();
        }
    }
}