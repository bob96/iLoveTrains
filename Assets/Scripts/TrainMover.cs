using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour {

    private Rigidbody rb;
    public float trainThrust;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
	}

    private void Update()
    {
        rb.transform.Translate(Vector3.forward * trainThrust * Time.deltaTime); 
    }
}
