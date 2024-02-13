using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour

{

    public GameObject[] prefabsObstacle;
    public GameObject player;
    [SerializeField] public GameObject gameOverPanel;
    private Vector3 spawnpoint;
    private int nbLife = 3;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;
    private int desiredLanespawn;



    void Start()
    {
        gameOverPanel.SetActive(false);
        ScheduleRandomObstacle();
    }


    private void ScheduleRandomObstacle()
    {
        float randomDelay = Random.Range(0.1f, 2.0f); // Choisir une plage de d�lais al�atoires
        Debug.Log("Next Obstacle delay in " + randomDelay + " seconds.");
        Invoke("DelayOfObstacle", randomDelay);
    }


    private void DelayOfObstacle()
    {
        GenerateObstacle();
        ScheduleRandomObstacle();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("J'ai touch� un obstacle dont le nom est " + other.name);
            //detrire l objet qui a le tag player
            DestroyPlayer();
            audioSource.PlayOneShot(audioClip, volume);

        }
    }


    private void GenerateObstacle()
    {
        desiredLanespawn = Random.Range(0, 3);
        float xcoodonate = transform.position.x;
        float ycoodonate = transform.position.y;
        float zcoodonate = transform.position.z;
        float[] spwnco = { -3.25f, 0.25f, 3.25f };


        int randomIndex = Random.Range(0, prefabsObstacle.Length);
        GameObject obstacle = prefabsObstacle[randomIndex];
        spawnpoint = new Vector3(xcoodonate - 100f, 0.686801f, spwnco[desiredLanespawn]);
        Instantiate(obstacle, spawnpoint, Quaternion.identity);


    }

    private void DestroyPlayer()
    {
        nbLife--;
        if (nbLife == 0)
        {

            Destroy(player);
            gameOverPanel.SetActive(true);
        }
    }


}

