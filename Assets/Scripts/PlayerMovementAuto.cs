using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerMovementAuto : MonoBehaviour
{


    public Rigidbody rigidbody = null;

    private float speed = -0.001f;

    void Start()
    { 
    }


    void Update()
    {
        rigidbody.transform.position = new Vector3(rigidbody.transform.position.x - speed, rigidbody.transform.position.y, rigidbody.transform.position.z);
        speed += 0.000008f;
    }
}

