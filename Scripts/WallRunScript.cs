using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WallRunScript : MonoBehaviour
{
    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();

    }
    float horizontalInput;
    float verticalInput;
    private float wallCheckDistance = 1f;
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    private RaycastHit wallRightHit;
    private RaycastHit wallLeftHit;
    private bool wallRight;
    private bool wallLeft;


    private float minJumpHeight;

    public void nearWall()
    {
        wallRight = Physics.Raycast(transform.position, transform.right, out wallRightHit, wallCheckDistance);
        wallLeft = Physics.Raycast(transform.position, -transform.right, out wallLeftHit, wallCheckDistance);
    }

    public bool aboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight);
    }

    public void playerState()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if((wallLeft || wallRight) && verticalInput > 0 && aboveGround())
        {
            //start
        }
    }
    
}
