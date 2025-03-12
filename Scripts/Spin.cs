using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spin : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        // rotates about y axis to spin character (pitch, yaw, roll)
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
