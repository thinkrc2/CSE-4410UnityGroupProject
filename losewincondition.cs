using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WinorLose : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject winScreen;
    public GameObject loseScreen;
    public Text status; //assign in Inspector pls
    public enum GameState { Win, Lose };
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            currentState = GameState.Win;
            winScreen.SetActive(true);
            audioSource.Play();
            status.text = "You Win! :)";
            status.color = Color.green;
        }

        else if (other.CompareTag("AI"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            currentState = GameState.Lose;
            loseScreen.SetActive(true);
            audioSource.Play();
            status.text = "You Lose :( Try Again?";
            status.color = Color.red;
        }
    }
}