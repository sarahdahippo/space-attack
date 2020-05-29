using UnityEngine;
using System.Collections;
public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            // Code to destroy itself is handled by Boundary
            return;
        }
        // The following code is for creating explosions when an object gets into contact with the hazard
        Instantiate(explosion, transform.position, transform.rotation);
        // The following code is for creating explosions when the player gets into contact with the hazard
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver(); // Game over for player
        }
        gameController.AddScore(scoreValue); // Adds score
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}