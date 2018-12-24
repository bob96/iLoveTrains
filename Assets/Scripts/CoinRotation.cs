using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour {

    public float tumble;

   
    // Update is called once per frame
    void Update () {

        transform.Rotate(Vector3.forward * Time.deltaTime * tumble);

	}
}
