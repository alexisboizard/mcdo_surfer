using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCar : MonoBehaviour
{
    public float speed = 10.0f;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
