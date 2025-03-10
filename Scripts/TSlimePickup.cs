using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TSlimePickup : MonoBehaviour
{
    private float speed = 18f;
    private float moveTimer = 2f;
    // size determines space taken up in inventory, supply is how many times it can be used after pickup
    private int size = 1;
    private int supply = 1;

    // makes the object float and spin so it isn't static
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        if (moveTimer > 0f)
        {
            transform.Translate(0, (0.1f * Time.deltaTime), 0);
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0f)
            {
                moveTimer = -2f;
            }
        }
        if (moveTimer < 0f)
        {
            transform.Translate(0, (-0.1f * Time.deltaTime), 0);
            moveTimer += Time.deltaTime;
            if (moveTimer >= 0f)
            {
                moveTimer = 2f;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        InventoryScript inventory = other.GetComponent<InventoryScript>();
        ProjectShooter projectshooter = other.GetComponentInChildren<ProjectShooter>();

        if (inventory != null)
        {
            if(inventory.checkInventory(size))
            {
                projectshooter.addTSlimeAmmo(supply);
                Destroy(this.gameObject);
            }
        }


    }
}
