using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
 
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer children;
    private Animator animator;

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        children = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetKeyDown (KeyCode.UpArrow) && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetKeyUp (KeyCode.UpArrow)) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x > 0.01f)
        {
            if(spriteRenderer.flipX == true)
            {
                EventManager.TriggerEvent("flipsword");
                spriteRenderer.flipX = false;
                children.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                EventManager.TriggerEvent("flipsword");
                spriteRenderer.flipX = true;
                children.flipX = true;
            }
        }

        //animator.SetBool ("grounded", grounded);
        //animator.SetFloat ("velocityX", Mathf.Abs (velocity)x) / maxSpeed);
        animator.SetFloat("speed", Mathf.Abs(move.x));
        targetVelocity = move * maxSpeed;
    }

    /*
    void Update()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move.x));
    }
    */
}