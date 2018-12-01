using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject[] train;

    private void Start()
    {
        int rand = Random.Range(0, train.Length);
        Instantiate(train[rand], transform.position, Quaternion.identity);
    }
}
