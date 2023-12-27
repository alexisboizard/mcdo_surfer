using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuggets_recolt : MonoBehaviour
{

    public GameObject recoltPrefab;
    private Vector3 spawnpoint;

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
        
        //Check if object touched has coin tag 
        if(collision.gameObject.tag == "Coin")
        {
            GenerateNugget();
            Debug.Log("J'ai touché un coin");
            //Detruit l objet colisionner
            collision.gameObject.gameObject.SetActive(false);
        }
    }



}
