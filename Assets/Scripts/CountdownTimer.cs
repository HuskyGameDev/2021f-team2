using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour

{

    public float remainingTime = 60;
    public bool timerActive = false;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
        remainingTime = 60;
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
            } else if (remainingTime == 0)
            {
               //SceneManager.loadScene();
            }
        }
        else
        {
            remainingTime = 0;
            timerActive = false;
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
