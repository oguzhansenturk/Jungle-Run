using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rgdbody2D;
    public float jump;
    public LayerMask ground;
    public LayerMask deathGround;
    private Collider2D playerCollider;
    private Animator animator;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public float mileStone;
    private float mileStoneCount;
    public float speedMultipier;

    public GameManager gameManager;
    private ScoreManager scoreManager;
    private Touch theTouch;

    void Start()
    {
        rgdbody2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        mileStoneCount = mileStone;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(playerCollider, deathGround);

        if (dead)
        {
            GameOver();
        }

        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed *= speedMultipier;
            mileStone += mileStone * speedMultipier;
            Debug.Log("M" + mileStone + ", MC" + mileStoneCount + "MS" + speed);
            scoreManager.level += 1;
        }

        rgdbody2D.velocity = new Vector2(speed, rgdbody2D.velocity.y);

        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        if (Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                jumpSound.Play();
                rgdbody2D.velocity = new Vector2(rgdbody2D.velocity.x, jump);
            }
        }


        //if (Input.touchCount > 0)
        //{
        //    theTouch = Input.GetTouch(0);

        //    if (theTouch.phase == TouchPhase.Ended)
        //    {
        //        if (grounded)
        //        {
        //            jumpSound.Play();
        //            rgdbody2D.velocity = new Vector2(rgdbody2D.velocity.x, jump);
        //        }
        //    }


        //}


        //if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (grounded)
        //    {
        //        jumpSound.Play();
        //        rgdbody2D.velocity = new Vector2(rgdbody2D.velocity.x, jump);
        //    }

        //}

        animator.SetBool("Grounded", grounded);

    }

    void GameOver()
    {
        gameManager.GameOver();
    }
}
