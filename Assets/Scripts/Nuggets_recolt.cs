using System.Collections;
using System.Collections.Generic;
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
        float ycoodonate = transform.rotation.y;
        float zcoodonate = transform.position.z;



        spawnpoint = new Vector3(xcoodonate - 50f, ycoodonate+2f, zcoodonate);
        Instantiate(recoltPrefab, spawnpoint, Quaternion.identity);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GenerateNugget();
        //Check if object touched has coin tag 
        if (collision.gameObject.tag == "Coin")
        {
            
            Debug.Log("J'ai touché un coin");
            //Detruit l objet colisionner
            string text = scoreText.text;
            if (float.TryParse(text, out float originalNumber)) { 
            float newnumber = originalNumber * 2;
                scoreText.text = newnumber.ToString();
            }
            else
            {
                Debug.Log("g pas pu pârse");
            }
            Destroy(collision.gameObject.gameObject);
        }
    }



}
