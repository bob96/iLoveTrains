using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelByContact : MonoBehaviour {

    public static bool changeLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            changeLevel = true;
            Debug.Log("Triggered");
        }
    }
}
