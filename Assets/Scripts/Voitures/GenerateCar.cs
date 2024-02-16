using TMPro;
using UnityEngine;

public class GenerateCar : MonoBehaviour
{

    public GameObject recoltPrefab;
    private Vector3 spawnpoint;
    private int desiredLanespawn;

    public void Start()
    {
        ScheduleRandomDelayOfNuggets();
    }

    private void ScheduleRandomDelayOfNuggets()
    {
        float randomDelay = Random.Range(5.0f, 10.0f); // Choisir une plage de dlais al�atoires
        Invoke("delay", randomDelay);
    }

    private void delay()
    {
        GenerateNewCar(); // Appeler votre fonction existante
        ScheduleRandomDelayOfNuggets(); // Planifier le prochain appel avec un dlai alatoire
    }


    private void GenerateNewCar()
    {
        desiredLanespawn = Random.Range(0, 3);
        float xcoodonate = transform.position.x;
        float ycoodonate = transform.position.y;
        float zcoodonate = transform.position.z;
        float[] spwnco = { -3.25f, 0.25f, 3.25f };

        spawnpoint = new Vector3(xcoodonate - 50f, ycoodonate, spwnco[desiredLanespawn]);
        Instantiate(recoltPrefab, spawnpoint, Quaternion.identity);
        xcoodonate -= 2f;
    }
}