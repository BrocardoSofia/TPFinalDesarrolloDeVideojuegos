using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int health;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite noHeart;
    [SerializeField] Image heart1;
    [SerializeField] Image heart2;
    [SerializeField] Image heart3;

    private void Start()
    {
        health = 6;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            health--;

            HeathBar();

            if(health == 0)
            {
                Die();
            }
            else
            {
                anim.SetTrigger("hit");
            }
        }
        else
        {
            anim.ResetTrigger("hit");
        }
    }

    private void HeathBar()
    {
        switch(health)
        {
            case 0:
                //quitar ultimo corazon
                heart3.sprite = noHeart;
                break;
            case 1:
                //quitar medio al ultimo corazon
                heart3.sprite = halfHeart;
                break;
            case 2:
                //quitar segundo corazon
                heart2.sprite = noHeart;
                break;
            case 3:
                //quitar media vida al segundo corazon
                heart2.sprite = halfHeart;
                break;
            case 4:
                //quitar el ultimo corazon
                heart1.sprite = noHeart;
                break;
            case 5:
                //quitar media vida al ultimo corazon
                heart1.sprite = halfHeart;
                break;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void GameOver()
    {
        //agregar pantalla de game over con el puntaje y un boton de casita para volver al menu principal
        Debug.Log("GameOver");
    }

}
