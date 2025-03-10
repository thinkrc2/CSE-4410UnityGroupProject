using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlimeBall : MonoBehaviour
{
    private float speed = 10f;
    // modifier reduces player movement speed to a percentage of the original
    private float modifier = 0.6f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.modifySpeed(modifier);
        }

        Destroy(this.gameObject);
    }
}
