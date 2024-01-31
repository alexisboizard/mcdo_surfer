using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateCar : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject player;
    public int interval = 5;


    public void Update()
    {
        // Generate a car every 5 seconds
        if (Time.frameCount % (interval * 60) == 0)
        {
            generateCar();
        }
        destroyCar();
    }
    private void generateCar()
    {
        int lane = Random.Range(1, 4);
        Vector3 carPosition = new Vector3(0, 0, 0);
        if (lane == 1)
        {
            carPosition = new Vector3(-3.25f, 0, 0);
        }
        else if (lane == 2)
        {
            carPosition = new Vector3(0.25f, 0, 0);
        }
        else if (lane == 3)
        {
            carPosition = new Vector3(3.25f, 0, 0);
        }
        GameObject car = Instantiate(carPrefab, carPosition, Quaternion.identity);
        Instantiate(car);
    }
    private void destroyCar()
    {
        GameObject[] carList = GameObject.FindGameObjectsWithTag("Car");
        float playerPosition = player.transform.position.z;

        for (int i = 0; i < carList.Length; i++)
        {
            float carPosition = carList[i].transform.position.z;
           // Debug.Log(i + " = " + (carPosition - playerPosition));
            if (carPosition - playerPosition > -5)
            {
                Debug.Log("Destroy");
                Destroy(carList[i]);
            }
        }
    }
}