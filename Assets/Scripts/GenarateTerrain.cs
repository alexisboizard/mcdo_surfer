using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenarateTerrain : MonoBehaviour
{

    public GameObject terrainPrefabs;

    private int xcordinate = -210;


    private void OnTriggerEnter(Collider other)
    {
        GenerateTerain();
        xcordinate -= 70;
    }


    private void GenerateTerain()
    {
        Vector3 spawnpoint = new Vector3(xcordinate, 0, 0);
        Instantiate(terrainPrefabs, spawnpoint, Quaternion.identity);
    }
}
