using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {

    public GameController game;
    public GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, -5, player.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            game.GameOver();
        }
    }
}
