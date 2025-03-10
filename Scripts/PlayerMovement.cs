using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 12f;
    public float speed = 12f;
    public float gravity = -9.8f;

    public float jumpSpeed = 4.9f;
    public float vertMovement;

    public float timer = 3.0f;

    private CharacterController characterController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // changes speed by the modifier value of items
    public void modifySpeed(float modifier)
    {
        speed *= modifier;
    }

    void Update()
    {
        //5 second timer before speed returns to normal
        if(speed != baseSpeed)
        {
            if(timer < 0f)
            {
                speed = baseSpeed;
                timer = 5f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, speed);

        // adds downward velocity over time
        vertMovement += gravity * Time.deltaTime;

        if (Input.GetKeyDown("space") && characterController.isGrounded)
        {
            vertMovement = jumpSpeed;
        }

        movement.y = vertMovement;

        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}