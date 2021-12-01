using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameTimer : MonoBehaviour

{
    public float totalTime = 5;
    float remainingTime;
    public bool timerActive = false;
    public Text timeText;
    private Minigame mg;

  

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
        remainingTime = totalTime;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                //displayTime(remainingTime);
            }
            else if (remainingTime <= 0)
            {

                mg = FindObjectOfType<Minigame>();

                if (mg.getPlayer1Mash() > mg.getPlayer2Mash())
                {
                    SceneManager.LoadScene("SampleScenep1");
                }
                else if (mg.getPlayer1Mash() < mg.getPlayer2Mash())
                {
                    SceneManager.LoadScene("SampleScenep2");
                }
                else
                {
                    SceneManager.LoadScene("SampleScene");
                }
                    //change scene

            }
        }
        else
        {
            remainingTime = 0;
            timerActive = false;
        }
    }
    /*
    void displayTime(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time % 1) * 100;

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (remainingTime <= 10 && remainingTime > 0)
        {
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
        if (remainingTime == 0)
        {
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
    */
}

