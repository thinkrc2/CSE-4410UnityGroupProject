using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject Player;
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Cube")
        {
            SceneManager.LoadScene("YouWin");
        }
        

    }
}