using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject slimeballPrefab;
    private GameObject slimeball;

    void update()
    {
        bool paused = Input.GetKeyDown("Escape");
        if (paused)
        {

            slimeball = Instantiate(slimeballPrefab) as GameObject;
            slimeball.transform.position = transform.TransformPoint(Vector3.forward* 1.5f);
            slimeball.transform.rotation = transform.rotation;
            Debug.Log("Congrats, you paused!");

        }
    }
}
