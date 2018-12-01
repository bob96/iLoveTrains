using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    static Music music = null;
    private void Awake()
    {
        if(music != null)
        {
            Destroy(gameObject);
        }
        else
        {
            music = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
