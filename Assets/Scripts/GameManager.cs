using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum playerSkin { mask, frog, pink, blue};
    private playerSkin skin;
    private int score = 0;

    public void addScore(int points)
    {
        score += points;
    }

    public void SaveScore()
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    public int getScore()
    {
        return score;
    }

    public void setSkin(int skinSelected)
    {
        switch(skinSelected)
        {
            case 1:
                skin = playerSkin.mask;
                break;
            case 2:
                skin = playerSkin.frog;
                break;
            case 3:
                skin = playerSkin.pink;
                break;
            case 4:
                skin = playerSkin.blue;
                break;
        }
    }
}
