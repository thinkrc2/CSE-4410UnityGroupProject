using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishAI : MonoBehaviour
{
    public GameObject AI;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Cube")
        {
            SceneManager.LoadScene("YouLose");
        }


    }
}