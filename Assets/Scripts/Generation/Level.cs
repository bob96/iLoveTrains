using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour {

    //public 
    public GameObject levelBorder;
    public GameObject[] trains;
    public int levelSize;
    public float offset;


    public void GenerateLevel()
    {
        Vector3 leftTrainPosition = new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z + 4.5f);
        Vector3 rightTrainPosition = new Vector3(transform.position.x + 4.5f + 6f, transform.position.y, transform.position.z + 4.5f);
        for (int i=0; i<levelSize; i++)
        {
            float leftRandomX = Random.Range(leftTrainPosition.x - 1.5f, leftTrainPosition.x + 1.5f);
            float leftRandomY = Random.Range(leftTrainPosition.z - 1.5f, leftTrainPosition.z + 1.5f);
            int rand = Random.Range(0, trains.Length);
            //intantiate left
            GameObject leftTrainClone =  Instantiate(trains[rand], new Vector3(leftRandomX, leftTrainPosition.y, leftRandomY) , Quaternion.identity);
            leftTrainClone.transform.parent = gameObject.transform;
            rand = Random.Range(0, trains.Length);
            float randomX = Random.Range(rightTrainPosition.x - 1.5f, rightTrainPosition.x + 1.5f);
            float randomY = Random.Range(rightTrainPosition.z - 1.5f, rightTrainPosition.z + 1.5f);
            //instantiate right
            GameObject rightTrainClone = Instantiate(trains[rand], new Vector3(randomX, rightTrainPosition.y, randomY), Quaternion.identity);
            rightTrainClone.transform.parent = gameObject.transform;
            leftTrainPosition = new Vector3(leftTrainPosition.x, leftTrainPosition.y, leftTrainPosition.z + 15f);
            rightTrainPosition = new Vector3(rightTrainPosition.x, rightTrainPosition.y, rightTrainPosition.z + 15f);
        }
        Vector3 BorderPos = new Vector3(-1, leftTrainPosition.y + 6f, leftTrainPosition.z);
        GameObject endLevel = Instantiate(levelBorder,BorderPos, Quaternion.identity);
        endLevel.transform.parent = gameObject.transform;
        offset = BorderPos.z;
    }
    /*private void Start()
    {
        GenerateLevel();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        GenerateLevel();
    }*/
}
