using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour {

    public GameObject[] trainPatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float increaseTime;
    public float maxTime = 1.5f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {

            int rand = Random.Range(0, trainPatterns.Length);
            Instantiate(trainPatterns[rand], transform.position, Quaternion.identity);

            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn < maxTime)
            {
                startTimeBtwSpawn += increaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }



}
