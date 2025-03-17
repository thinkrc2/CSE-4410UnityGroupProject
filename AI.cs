using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AI : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 50f;
    public float rotationSpeed = 200f;
    int index = 0;
    public float initialXOffset = 0f;
    public float initialZOffset = 0f;


    // Update is called once per frame
    private void Update()
    {
        // Move Forward to Waypoints
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);

        // (added by Jean) makes AI rotate towards finish line
        Vector3 direction = destination - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            Vector3 eulerRotation = targetRotation.eulerAngles;
            eulerRotation.x = 0;
            eulerRotation.z = 0;
            Quaternion newRotation = Quaternion.Euler(eulerRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = transform.rotation * Quaternion.Euler(initialXOffset, 0, initialZOffset);
        }
    
        

	// end of additional code 

	   // Makes sure AI moves
        if (distance <= 0.05)
        {
            index++;
        }

    }
}