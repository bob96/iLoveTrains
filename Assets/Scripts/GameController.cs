using System.Collections; 
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    //private
    public int score;
    public bool gameOver;
    private bool restart;
    private bool startTheGame;
    private Vector3 spawnPosition;
    private bool newBest;
    //public
    public Text scoreText;
    public GameObject gameOverLayout;
    public int scoreValue;
    public LevelChanger levelChanger;
    public Text gameOverText;
    public Text HighScoreText;



    private void Start()
    {
           
        
        score = 0;
        scoreText.text = " score :" + score;    
        restart = false;
        gameOver = false;

        GameObject levelChangerObject = GameObject.FindWithTag("LevelChanger");

        if (levelChangerObject != null)
        {
            levelChanger = levelChangerObject.GetComponent<LevelChanger>();
        }
        else if (levelChangerObject)
        {
            Debug.Log("gameController script is not found!");
        }

    }

    private void Update()
    {
        
        
        if (gameOver)
        {
            gameOverLayout.SetActive(true);
            UpdateHighScore(score);
            if (newBest)
            {
                HighScoreText.text = "your new best : " + PlayerPrefs.GetInt("HighScore");
            }
            else
            {
                HighScoreText.text = "your best : " + PlayerPrefs.GetInt("HighScore");
            }
                  
        }
    }

    void UpdateHighScore(int score)
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            newBest = true;
        }
        else
        {
            newBest = false;
        }
         
    }
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score : " +score;
    }

    //ending the game
    public void GameOver()
    {
       
        gameOver = true;
    }
    public int GetScore()
    {
        return score;
    }
    //restart the game
    void AddOneToScore()
    {
        AddScore(1);
    }
    public void Restart()
    {
        restart = true;
    }
}
