using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouselookJ : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum RotationAxes {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    public float verticalRot = 0;


    void Update() {
        if(axes == RotationAxes.MouseX)
        {
            //Rotates camera about y axis
           transform.Rotate(0, sensitivityHor * Input.GetAxis("Mouse X"), 0);
        } else if(axes == RotationAxes.MouseY)
        {
            //Rotates camera about x axis. clamp is used to prevent character from doing flips
           verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; ;
           verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        } else
        {
            //Rotates camera on both axes when both input is detected
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert; ;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);

        }



    }
}
