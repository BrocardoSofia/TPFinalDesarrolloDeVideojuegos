using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private AudioSource pressSoundEffect;
    void doExitGame()
    {

        Application.Quit();
    }
}
