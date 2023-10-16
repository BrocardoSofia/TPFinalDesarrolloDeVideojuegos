using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int health;

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
            Debug.Log(health);

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

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void GameOver()
    {

    }

}
