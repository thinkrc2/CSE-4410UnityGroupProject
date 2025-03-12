using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedBoost : MonoBehaviour
{

    private float speed = 18f;
    // modifier increases player movement speed to a percentage of the original
    private float modifier = 1.4f;
    private float moveTimer = 2f;

    [SerializeField] AudioClip collision;


    void Update()
    {
        // makes the object float and spin so it isn't static
        transform.Rotate(0, speed * Time.deltaTime, 0);
        if (moveTimer > 0f)
        {
            transform.Translate(0, (0.1f * Time.deltaTime), 0);
            moveTimer -= Time.deltaTime;
            if(moveTimer <= 0f)
            {
                moveTimer = -2f;
            }
        }
        if (moveTimer < 0f)
        {
            transform.Translate(0, (-0.1f * Time.deltaTime), 0);
            moveTimer += Time.deltaTime;
            if(moveTimer >= 0f)
            {
                moveTimer = 2f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.modifySpeed(modifier);
        }

        // Creates audio source at object's position, then destroys it when clip ends
        // otherwise the clip ends when the object is destroyed
        AudioSource.PlayClipAtPoint(collision, transform.position);

        Destroy(this.gameObject);
    }
}
