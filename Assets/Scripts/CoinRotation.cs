using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour {

    public float tumble;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    // Update is called once per frame
    void Update () {

        transform.Rotate(Vector3.forward * Time.deltaTime * tumble);

	}
}
