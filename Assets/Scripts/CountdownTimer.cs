using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour

{
    public float totalTime = 5;
    float remainingTime;
    public bool timerActive = false;
    public Text timeText;

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
                displayTime(remainingTime);
            }
            if (remainingTime <= 0)
            { 
                timerActive = false;


                float m = Random.Range(0f, .999f);
                int minigameSelector = (int)m;

                if (minigameSelector == 0)
                {
                    SceneManager.LoadScene("Minigame Button Mashing");
                }
                else
                {
                    //more minigames
                }
            }

        }   
        
        
    }

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
}
