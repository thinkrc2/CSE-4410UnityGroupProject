using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fpsscriptJ : MonoBehaviour
{

    public float speed = 3f;
    public float gravity = -9.8f;

    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;// * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed;// * Time.deltaTime;

        //transform.Translate(deltaX, 0, deltaZ);


        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //clamp vector to limit speed
        movement = Vector3.ClampMagnitude(movement, speed);

        //applies gravity to keep character on floor
        movement.y = gravity;
        
        //multiplies movement speed. Faster fps causes faster speed without this
        movement *= Time.deltaTime;

        //changes direction of character when moved
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}
