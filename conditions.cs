using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/* IMPORTANT NOTE:

MAKE SURE PLAYER AND AI ARE TAGGED CORRECTLY AND BOTH HAVE COLLIDERS !
FINISH LINE OBJECT NEEDS A COLLIDER ENABLED, TOO !

*/



public class FinishLine : MonoBehaviour
{
    public WinLoseConditions winLoseConditions;
    public bool isAI = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winLoseConditions.IncrementPlayerLaps();
        }
        else if (other.CompareTag("AI") && isAI)
        {
            winLoseConditions.IncrementAILaps();
        }
    }

    /*
      private void OnTriggerEnter(Collider other)
    {
        if (gameFinished) return;

        if (other.gameObject.CompareTag("Player"))
        {
            //other.GetComponent<BoxCollider>().enabled = false;
            WinGame();
        }

        else if (other.gameObject.CompareTag("AI"))
        {
            //other.GetComponent<BoxCollider>().enabled = false;
            LoseGame(); 
        }
    }
    */
}


public class WinLoseConditions : MonoBehaviour
{
    public GameObject winScreen; //instead of text being displayed, displays an entire screen
    public GameObject loseScreen; 
    public AudioSource winSound;
    public AudioSource loseSound;
    public Button restartbutton;

    public int lapsToWin = 3; //need to set in inspector

    //starts fame with no laps completed
    public int playerLaps = 0;
    public int AILaps = 0;

    //make it clear that game isn't finished so win and lose functions don't occur randomly
    private bool gameFinished = false;

      public void IncrementPlayerLaps()
    {
        if (playerLaps < lapstoWin)
        {
            playerLaps++;
            CheckWin();
            Debug.Log("Player laps");

        }
    }

    public void IncrementAILaps()
    {
        if (AILaps < lapstoWin)
        {
            AILaps++;
            CheckLose();
            Debug.Log("AI laps");
        }
    }


    private void CheckWin()
    {
        if (playerLaps >= lapsToWin && !gameFinished)
        {
            WinGame();
        }
    }

    private void CheckLose()
    {
        if (AILaps >= lapsToWin && !gameFinished)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        gameFinished = true;
        if (winScreen != null) winScreen.SetActive(true);
        if (winSound != null) winSound.Play();
        Debug.Log("Player Wins!");
        if (restartButton != null) restartButton.gameObject.SetActive(true);

        /*
         finished = true;
        winScreen.SetActive(true);
        winSound.Play();
        */
    }

    private void LoseGame()
    {
        gameFinished = true;
        if (loseScreen != null) loseScreen.SetActive(true);
        if (loseSound != null) loseSound.Play();
        Debug.Log("AI Wins!");
        if (restartButton != null) restartButton.gameObject.SetActive(true);

        /*
        finished = true;
        loseScreen.SetActive(true);
        loseSound.Play();
        */
    }

    public void Restart()
    {
        Debug.Log("Restart"); //will see if it works, "Restart" appears in console

        //load by scene name
        SceneManager.LoadScene(mainmenuName); //make sure (mainmenuName) is what it's called...
   
    }
}