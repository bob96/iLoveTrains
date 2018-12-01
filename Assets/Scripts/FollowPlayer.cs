using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 startPosition;
    private Vector3 offset;
    
	// Use this for initialization
	void Start () {
        if(player != null)
        {
            offset = new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y, transform.position.z - player.position.z);
            startPosition = transform.position;
        }
        else if(player == null)
        {
            return;
        }
       
               
	}
	
	// Update is called once per frame
	void Update () {

        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offset.x,startPosition.y, player.position.z + offset.z);
        }
        else if (player == null)
        {
            return;
        }
        
	}
}
