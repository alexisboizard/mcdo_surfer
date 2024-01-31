using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour

{

    public GameObject[] prefabsObstacle;
    public GameObject player;
    [SerializeField] public GameObject gameOverPanel;
    private int nbLife = 3;
    private bool isGameOver = false;



    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("J'ai touché un obstacle dont le nom est " + other.name);
            //detrire l objet qui a le tag player
            DestroyPlayer();
        }
    }


    private void GenerateObstacle()
    {
        
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

