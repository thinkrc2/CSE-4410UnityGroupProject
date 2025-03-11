using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : MonoBehaviour
{

    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health + {health}");

    }


    // Update is called once per frame
    void Update()
    {
        if(health < 1)
        {
            Debug.Log($"You Died");
            health = 5;
        }

    }
}
