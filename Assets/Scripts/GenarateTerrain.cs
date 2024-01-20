using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenarateTerrain : MonoBehaviour
{

    public GameObject[] prefabs;
    // 0 -> ClassicSteet
    // 1 -> Classic Street without McDo 
    // 2 -> Asian Street

    private float xcordinate = -475f;
    //private float xcordinate = -380f;
    private int lastPrefabIndex = 0;
    private int prefabIndex = 0;
    private bool isFirstExecution = true;
    private Vector3 spawnpoint;
    private int counter = 0;

    private void OnTriggerEnter(Collider other)
    {
        prefabIndex = Random.Range(0, 2);
        Debug.Log("J'ai touché mdr");
        GenerateTerain();
        //xcordinate += -185.3f;
        xcordinate -= 280f;
        prefabIndex = 0;
    }

    private void GenerateTerain()
    {
        spawnpoint = new Vector3(xcordinate, 17.83334f, -9.2f);
        //spawnpoint = new Vector3(xcordinate, 0.9f, 4.5f);
        Instantiate(prefabs[0], spawnpoint, Quaternion.identity);
        lastPrefabIndex = prefabIndex;
        counter++;
    }
}
