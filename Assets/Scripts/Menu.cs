using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore") + " pts";
        }
        else
        {
            highScore.text = "HighScore: " + 0 + " pts";
        }
    }
}
