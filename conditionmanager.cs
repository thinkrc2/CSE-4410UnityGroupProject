using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionsManager : MonoBehaviour
{
    public string winSceneName = "YouWin";
    public string loseSceneName = "YouLose";

    public void PlayerWins()
    {
        SceneManager.LoadScene(winSceneName);
    }

    public void AIWins()
    {
        SceneManager.LoadScene(loseSceneName);
    }
}