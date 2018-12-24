using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {

    public GameObject player;
    public float speed;
    public Swipe swipeControls;
    private Rigidbody rb;
    public float thrust;
    //private Vector3 desiredPosition;

    private void Start()
    {
        //desiredPosition = transform.position;
        rb = player.GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        Debug.Log(swipeControls.SwipeUp);

        if (swipeControls.SwipeUp )
        {
            rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
            
        }
        if (swipeControls.SwipeDown)
        {
            rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
        }

        //player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, speed * Time.deltaTime);
    }

   
}
