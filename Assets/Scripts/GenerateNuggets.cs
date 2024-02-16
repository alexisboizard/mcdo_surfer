using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateNuggets : MonoBehaviour
{

    public GameObject recoltPrefab;
    private Vector3 spawnpoint;
    public TMP_Text scoreText;

    private int desiredLanespawn;

    public void Start()
    {
        Debug.Log("start");
        ScheduleRandomDelayOfNuggets();
    }

    private void ScheduleRandomDelayOfNuggets()
    {
        float randomDelay = Random.Range(5.0f, 10.0f); // Choisir une plage de d�lais al�atoires
        Debug.Log("Next Nuggets delay in " + randomDelay + " seconds.");
        Invoke("DelayOfNuggets", randomDelay);
    }

    private void DelayOfNuggets()
    {
        GenerateNugget(); // Appeler votre fonction existante
        ScheduleRandomDelayOfNuggets(); // Planifier le prochain appel avec un d�lai al�atoire
    }


    private void GenerateNugget()
    {
        Debug.Log("generate nuggets");
        int nbnuggets = Random.Range(2, 5);
        desiredLanespawn = Random.Range(0, 3);

        float xcoodonate = transform.position.x;
        float ycoodonate = transform.position.y;
        float zcoodonate = transform.position.z;
        float[] spwnco = { -3.25f, 0.25f, 3.25f };

        for (int i = 0; i < nbnuggets; i++)
        {
            spawnpoint = new Vector3(xcoodonate - 50f, 1f, spwnco[desiredLanespawn]);
            Instantiate(recoltPrefab, spawnpoint, Quaternion.identity);
            xcoodonate -= 3f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            IncrementNumber();
            Destroy(collision.gameObject.gameObject);
        }
    }


    private void IncrementNumber()
    {
        string text = scoreText.text;


        if (float.TryParse(text, out float originalNumber))
        {
            float newnumber = originalNumber + 1;
            scoreText.text = newnumber.ToString();
        }
        else
        {
            Debug.Log("g pas pu parse");
        }
    }




}
