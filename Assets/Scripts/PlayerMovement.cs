using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedMultiplier = 0.1f; // Ajustez ce coefficient selon vos besoins
    public TMP_Text scoreText;

    private int desiredLane = 2; // 1: Left, 2: Middle, 3: Right
    Vector3 inputMovement = Vector3.zero;

    private float startTime;
    public float score;

    public GameObject[] prefabs;

    int numCarTouched = 0;

    private bool firstTimePlayed = true;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.5f;

    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        // Calcule le temps écoulé depuis le début du jeu
        float elapsedTime = Time.time - startTime;

        // Score basé sur le temps écoulé (ajuster la formule selon vos besoins)
        score = Mathf.Floor(elapsedTime);

        // Affiche ou utilise le score dans le jeu
        inputMovement.x = transform.position.x;
        inputMovement.y = transform.position.y;
        transform.position = inputMovement;
        float newSpeed = speed + score * speedMultiplier;

        // Applique la nouvelle vitesse au joueur
        transform.Translate(Vector3.forward * newSpeed * Time.deltaTime);
        scoreText.text = score.ToString();
        if (firstTimePlayed && score > 30)
        {
            firstTimePlayed = false;
            audioSource.PlayOneShot(audioClip, volume);

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Gestion des collisions avec les voitures
        if (collision.collider.tag == "Voitures")
        {
            if (numCarTouched >= 3)
            {
                Debug.Log("GameOver");
            }
        }
    }
    public void moveOnLane(int lane)
    {
        if (lane == 1)
        {
            inputMovement.z = -3.25f;
        }
        else if (lane == 2)
        {
            inputMovement.z = 0.25f;
        }
        else if (lane == 3)
        {
            inputMovement.z = 3.25f;
        }
    }
}
