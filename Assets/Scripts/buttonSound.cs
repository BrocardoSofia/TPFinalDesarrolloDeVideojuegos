using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class buttonSound : MonoBehaviour
{
    [SerializeField] private AudioSource mySounds;
    [SerializeField] private AudioClip mouseOverSoundEffect;
    [SerializeField] private AudioClip mouseClickSoundEffect;
    

    public void HoverSound()
    {
        mySounds.PlayOneShot(mouseOverSoundEffect);
    }

    public void ClickSound()
    {
        mySounds.PlayOneShot(mouseClickSoundEffect);
    }
}
