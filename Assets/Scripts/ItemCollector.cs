using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    [SerializeField] private Text text_apples;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Animator anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("collected");

            Destroy(collision.gameObject, 0.5f);
            apples++;
            text_apples.text = "Apples: " + apples;
        }
    }
}
