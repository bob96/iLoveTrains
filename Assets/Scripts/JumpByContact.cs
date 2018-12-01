using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByContact : MonoBehaviour {

    private Rigidbody rb;
    public GameObject bumpSound;
    public float thrust;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(bumpSound, transform.position, Quaternion.identity);           
           rb =  other.GetComponent<Rigidbody>();
           rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
           Destroy(gameObject, 2);
        }
    }
}
