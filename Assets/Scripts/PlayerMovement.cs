using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    private int desiredLane = 2; // 1: Left, 2: Middle, 3: Right

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
            if (desiredLane == 1)
                desiredLane = 2;
            else
                desiredLane = 3;
        }
        moveOnLane(desiredLane);
    }

    void moveOnLane(int lane)
    {
        if (lane == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3f);
        }
        else if (lane == 2)
        {
            transform.position = new Vector3(transform.position.y, transform.position.y, 0.0f);
        }
        else if (lane == 3)
        {
            transform.position = new Vector3(transform.position.y, transform.position.y, 3.0f);
        }
    }
}
