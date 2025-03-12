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



    // all variables related to wallrunning
    private float horizontalInput;
    private float verticalInput;
    private float wallCheckDistance = 0.6f;
    private LayerMask whatIsWall;
    private LayerMask whatIsGround;
    private RaycastHit wallRightHit;
    private RaycastHit wallLeftHit;
    private bool wallRight;
    private bool wallLeft;
    private float minJumpHeight = 1f;
    private bool aboveGround;
    private float wallrunspeed = 0f;
    private bool walljump;
    private float walljumptimer;
    private bool timenotexceeded;
    private float wallruntime;
    private float waittime;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        walljump = false;
        timenotexceeded = true;
        wallruntime = 0f;
    }

    // changes speed by the modifier value of items
    public void modifySpeed(float modifier)
    {
        speed *= modifier;
    } 

    void Update()
    {
        //5 second timer before speed returns to normal
        if(speed != baseSpeed + wallrunspeed)
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

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        aboveGround = !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);

        if ((wallLeft || wallRight) && verticalInput > 0 && aboveGround && !walljump && timenotexceeded)
        {
            vertMovement = 0 + gravity * Time.deltaTime;
            wallrunspeed = 1f;
            wallruntime += Time.deltaTime;
            if(wallruntime > 4f)
            {
                timenotexceeded = false;
                waittime = 1f;
            }
            
            if (Input.GetKeyDown("space"))
            {
                vertMovement = jumpSpeed;
                walljump = true;
                walljumptimer = 1f;
            }
        }
        else
        {
            
            wallrunspeed = 0f;
            if (walljump)
            {
                if(walljumptimer > 0f)
                {
                    walljumptimer -= Time.deltaTime;
                }
                else
                {
                    walljump = false;
                }
            }
            if(waittime > 0f)
            {
                waittime -= Time.deltaTime;
            }
            else
            {
                timenotexceeded = true;
                wallruntime = 0f;
            }
        }
        

        wallRight = Physics.Raycast(transform.position, transform.right, out wallRightHit, wallCheckDistance);
        wallLeft = Physics.Raycast(transform.position, -transform.right, out wallLeftHit, wallCheckDistance);

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