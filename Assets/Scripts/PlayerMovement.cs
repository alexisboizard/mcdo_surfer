using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    private int desiredLane = 2; // 1: Left, 2: Middle, 3: Right
    public float playerLevel;

    private float thespeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLane == 3)
                desiredLane = 2;
            else
                desiredLane = 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow Pressed");
            if (desiredLane == 1)
                desiredLane = 2;
            else
                desiredLane = 3;
        }
        moveOnLane(desiredLane);
    }

    void moveOnLane(int lane)
    {
        Vector3 inputMovement = Vector3.zero;
        if (lane == 1)
        {
            inputMovement.z = -3f;
        }
        else if (lane == 2)
        {
            inputMovement.z = 0.0f;
        }
        else if (lane == 3)
        {
            inputMovement.z = 3.0f;
        }
        inputMovement.x = -1 * speed * Time.deltaTime* thespeed + transform.position.x;
      
        Debug.Log("speed :" + thespeed);
        inputMovement.y = transform.position.y;
        transform.position = inputMovement;
    }
}
