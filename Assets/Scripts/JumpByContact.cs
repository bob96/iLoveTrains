using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByContact : MonoBehaviour {

    private Rigidbody rb;
    public GameObject bumpSound;
    public float thrust;
    public static bool touched;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Instantiate(bumpSound, transform.position, Quaternion.identity);
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
            //rb.velocity = Vector3.up*thrust*Time.deltaTime;
            Destroy(gameObject, 2);
        }
    }
    
}
