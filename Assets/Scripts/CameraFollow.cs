using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera camera = null;
    public GameObject target = null;

    private void Update()
    {
        camera.transform.position = new Vector3(target.transform.position.x+5, target.transform.position.y+2, camera.transform.position.z);
    }
}
