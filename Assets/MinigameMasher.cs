using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MinigameMasher : MonoBehaviour
{
    int[] game = new int[2];


    // Start is called before the first frame update
    void Start()
    {
        game[0] = 0;
        game[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Player 1 Fire"))
        {
            game[0] = game[0] + 1;
        }
       if(Input.GetButtonDown("Player 2 Fire"))
        {
            game[1] = game[1] + 1;
        }
    }


    public int getPlayer1Mash()
    {
        return game[0];
    }
    public int getPlayer2Mash()
    {
        return game[1];
    }

}
