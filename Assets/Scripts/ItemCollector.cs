using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text text_apples;

    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            collectSoundEffect.Play();
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("collected");

            Destroy(collision.gameObject, 0.5f);
            gameManager.addScore(100);
            text_apples.text = gameManager.getScore() + " pts";
        }
    }
}
