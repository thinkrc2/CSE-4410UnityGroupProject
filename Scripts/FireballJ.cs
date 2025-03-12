using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireballJ : MonoBehaviour
{

    public float speed = 10f;
    public int damage = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacterJ player = other.GetComponent<PlayerCharacterJ>();

        if(player != null)
        {
            player.Hurt(damage);
        }

        Destroy(this.gameObject);
    }
}
