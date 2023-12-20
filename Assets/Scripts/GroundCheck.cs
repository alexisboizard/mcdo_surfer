using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGroundCheck { get; private set; } = false;
    void OnTriggerEnter(Collider collider)
    {
        isGroundCheck = true;
        Debug.Log("GroundCheck: OnTriggerEnter");
    }

    void OnTriggerExit(Collider collider)
    {
        isGroundCheck = false;
        Debug.Log("GroundCheck: OnTriggerExit");
    }
}
