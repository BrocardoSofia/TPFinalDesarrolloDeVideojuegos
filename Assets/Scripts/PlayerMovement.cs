using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX;
    private int jumpCount;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, appearing, desaesappearing, doubleJump}
    private MovementState state;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dirX = 0f;
        state = MovementState.idle;
        jumpCount = 0;

        //FALTA agregar sprite de personaje segun la skin que eliga el jugador
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.bodyType == RigidbodyType2D.Dynamic)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); //se mueve horizontalmente

            if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpCount < 2))
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //cuando salta
                jumpCount++;
            }

            UpdateAnimationState();
        }
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if((rb.velocity.y > .1f) && (jumpCount != 2))
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if(jumpCount == 2 && !IsGrounded())
        {
            state = MovementState.doubleJump;
        }
        else
        {
            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //creo una nueva caja que esta un poquito mas abajo que la caja del personaje
        //para ver si se superpone con otra caja
        bool grounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);

        if (grounded)
        {
            jumpCount = 0;
        }

        return grounded;
    }
}
