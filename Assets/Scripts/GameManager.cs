using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public FloatingTextManager floatingTextManager;
    private int score = 0;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            SceneManager.sceneLoaded += LoadState;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void SaveState()
    {
        int saveValue = score;

        PlayerPrefs.SetInt("SaveState", saveValue);

    }

    private void LoadState(Scene s, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("SaveState"))
        {
            //Load score
            score = PlayerPrefs.GetInt("SaveState");
        }


    }

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

    //Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
}
