using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private Level currentLevel, pastLevel, futurLevel;
    public GameObject CL, PL, FL;
    private Vector3 offSet;

   
    private void Awake()
    {
        SetLevels();

        currentLevel = CL.GetComponent<Level>();
        pastLevel = PL.GetComponent<Level>();
        futurLevel = FL.GetComponent<Level>();


        
    }
    //--------------------------------
    
    void Start () {
        currentLevel.GenerateLevel();
        pastLevel.transform.position = new Vector3(currentLevel.transform.position.x, currentLevel.transform.position.y, currentLevel.transform.position.z - currentLevel.offset);
        pastLevel.GenerateLevel();
        futurLevel.transform.position = new Vector3(currentLevel.transform.position.x, currentLevel.transform.position.y, currentLevel.transform.position.z + currentLevel.offset);
        futurLevel.GenerateLevel();
        offSet = new Vector3(0f, 0f, currentLevel.offset);
    }

    private void Update()
    {
        
        if (ChangeLevelByContact.changeLevel)
        {
            CL.tag = "PastLevel";
            PL.transform.position = FL.transform.position + offSet;
            PL.tag = "FuturLevel";
            FL.tag = "CurrentLevel";

            SetLevels();

            ChangeLevelByContact.changeLevel = false;
        }
    }

    void SetLevels()
    {
        PL = GameObject.FindGameObjectWithTag("PastLevel");
        CL = GameObject.FindGameObjectWithTag("CurrentLevel");
        FL = GameObject.FindGameObjectWithTag("FuturLevel");
    }
}
