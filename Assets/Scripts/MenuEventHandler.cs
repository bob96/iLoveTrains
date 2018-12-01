using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MenuEventHandler : MonoBehaviour {

    public GameObject option;
    public GameObject resume;
    public GameObject pauseInPause;
    public GameObject optionInPause;
    public AudioMixer audioMixer;
    public GameObject[] countDown;
    private bool timerDone = false;

    public void PauseInPause()
    {
        option.SetActive(false);
        pauseInPause.SetActive(true);
       
    }

    public void OptionInPause()
    {
        pauseInPause.SetActive(false);
        option.SetActive(true);
    }
    public void Pause()
    {
        
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            resume.SetActive(true);
            pauseInPause.SetActive(true);
            timerDone = false;
            
        }
    }

    /*void UnPauseTimer()
    {
        int i = 1;
        float timer = 3.0f;
        float timeBtwActives = 1.0f;
        while (timer < 0)
        {
            timer -= Time.deltaTime;
            while (i < 3)
            {
                while (timeBtwActives < 0)
                {
                    timeBtwActives -= Time.deltaTime;
                    if (i == 0)
                    {
                        countDown[i].SetActive(true);
                    }
                    else
                    {
                        countDown[i - 1].SetActive(false);
                        countDown[i].SetActive(true);
                    }

                }
                i++;
            }
            countDown[i].SetActive(false);
            
        }
        timerDone = true;
    }*/
    public void Resume()
    {
       
        pauseInPause.SetActive(false);
        resume.SetActive(false);
        //wait
        Time.timeScale = 1;
        timerDone = false;
        
    }

    //quit the game
    public void Quit()
    {
        Application.Quit();
    }
    // go to option ui
    public void Option()
    {
        option.SetActive(true);
        gameObject.SetActive(false);

    }
    //return to menu
    public void OptionBack()
    {
        option.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);

    }
}
