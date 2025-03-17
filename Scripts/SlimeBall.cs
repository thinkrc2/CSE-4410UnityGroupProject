using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlimeBall : MonoBehaviour
{
    private float speed = 10f;
    // modifier reduces player movement speed to a percentage of the original
    private float modifier = 0.6f;


    [SerializeField] AudioClip collision;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        AI ai = other.GetComponent<AI>();

        if (movement != null)
        {
            movement.modifySpeed(modifier);
        }
        else if(ai != null)
        {
            ai.modifySpeed(modifier);
        }

        // Creates audio source at object's position, then destroys it when clip ends
        // otherwise the clip ends when the object is destroyed
        AudioSource.PlayClipAtPoint(collision, transform.position);

        Destroy(this.gameObject);
    }
}
