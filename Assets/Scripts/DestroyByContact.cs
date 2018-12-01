using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject coinCollectionSound;
    public int scoreValue;
    public GameController gameController;


    private void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if( gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else if (gameControllerObject)
        {
            Debug.Log("gameController script is not found!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Coin"))
        {
            Destroy(gameObject);
            Instantiate(coinCollectionSound, transform.position, Quaternion.identity);
            Debug.Log("get the coin ");
            gameController.AddScore(scoreValue);
        }
        if(other.CompareTag("Player") && gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
            gameController.GameOver();

        }
        if(other.CompareTag("Train") && gameObject.CompareTag("TrainDestroyer"))
        {
            Destroy(other.gameObject);
            if (!gameController.gameOver)
            {
                gameController.AddScore(scoreValue);
            }
            
        }
    }
}
