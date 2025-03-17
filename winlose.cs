using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class FinishLineTrigger : MonoBehaviour
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
}

public class WinLoseConditions : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject finishLine;
    public GameObject player;
    public GameObject AI; 
    public GameObject winScreen;
    public GameObject loseScreen;
    public AudioSource winSound;
    public AudioSource loseSound;
    public float timeLimit = 120f; //in seconds
    public int AILaps = 0; 
    public int playerLaps = 0; 
    public int lapstoWin = 2; 
    private float startTime;
    private bool finished = false;

    void Start()
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);
            startTime = Time.time;
        }

    void Update()
        {
            if (player != null && finishLine != null && AI != null && !finished)
            {
                if (MetWinCondition())
                {
                    WinGame();
                }
                else if (MetLoseCondition())
                {
                    LoseGame();
                }
            }
        }

        bool MetWinCondition()
        {
            if (player.transform.position.z > finishLine.transform.position.z)
            {
                if(playerLaps < lapstoWin)
                {
                    playerLaps++;
                }
                if(playerLaps >= lapstoWin)
                {
                    return true;
                }
            }
            return false;
        }

        bool MetLoseCondition()
        {
            if (Time.time - startTime > timeLimit)
            {
                return true;
            }

            if (AI.transform.position.z > finishLine.transform.position.z)
            {
                if(AILaps < lapstoWin)
                {
                    AILaps++;
                }
                if(AILaps >= lapstoWin && playerLaps < lapstoWin)
                {
                    return true;
                }
            }

            return false;
        }

        void WinGame()
        {
            finished = true;
            winScreen.SetActive(true);
            winSound.Play();
        }

        void LoseGame()
        {
            finished = true;
            loseScreen.SetActive(true);
            loseSound.Play();
        }

        public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToHomepage()
    {
        SceneManager.LoadScene("Homepage");
    }
}