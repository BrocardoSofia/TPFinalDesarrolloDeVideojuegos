using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartScene : MonoBehaviour
{
    public void goHome()
    {
        SceneManager.LoadScene("Start");
    }
}
