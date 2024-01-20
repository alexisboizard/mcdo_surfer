using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Nuggets_recolt : MonoBehaviour
{

    public GameObject recoltPrefab;
    private Vector3 spawnpoint;
    public TMP_Text scoreText;

    private void GenerateNugget()
    {
        float xcoodonate = transform.position.x;
        float ycoodonate = transform.rotation.y + 2f;
        float zcoodonate = transform.position.z;

        int[] choices = { -3, 0, 3 };
        int randomIndex = Random.Range(0, choices.Length);

        spawnpoint = new Vector3(xcoodonate - 50f, ycoodonate, randomIndex);
        Instantiate(recoltPrefab, spawnpoint, Quaternion.identity);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GenerateNugget();
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
            Debug.Log("le old is " + originalNumber);
            float newnumber = originalNumber + 1;
            Debug.Log("le new is " + newnumber);
            scoreText.text = newnumber.ToString();
        }
        else
        {
            Debug.Log("g pas pu pârse");
        }
    }



}
