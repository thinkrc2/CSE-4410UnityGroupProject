using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackingSlime : MonoBehaviour
{
    public float speed = 10f;
    // modifier reduces player movement speed to a percentage of the original
    public float modifier = 0.8f;
    GameObject hitObject;

    [SerializeField] AudioClip collision;


    // All instances of Wandering AI can be replaced with the component that is attached to the AI
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        // path that the slime checks for a enemy/player
        if (Physics.SphereCast(ray, 4f, out hit))
        {
            hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<WanderingAI>() || hitObject.GetComponent<PlayerMovement>())
            {
                transform.LookAt(hitObject.transform);
                transform.position += (hitObject.transform.position - transform.position).normalized * speed * Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        WanderingAI enemy = other.GetComponent<WanderingAI>();

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
