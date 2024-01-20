using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGroundCheck { get; private set; } = false;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            isGroundCheck = true;
            Debug.Log("GroundCheck: OnCollisionEnter");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGroundCheck = false;
           
            Debug.Log("GroundCheck: OnCollisionExit");
        }
    }
}
