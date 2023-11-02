using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float jumpForce = 10f; 

    private Rigidbody2D rb;

    public bool isGround;
    public LayerMask whatIsGround;
    private Collider2D playerCollider;

    private Animator playerAnimator;

    public float jumpTime;
    private float jumpTimeCounter;

    public AudioSource jump;

   



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = rb.GetComponent<Collider2D>();
        playerAnimator = playerCollider.GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }

    void Update()
    {
        if(ManagerSingleton.instance.isPlay)
        {
            CheckGround();

            PlayerMove();

            

            
        }
        AnimatorPlayer();


    }
    void PlayerMove()
    {
        
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        //if (Input.GetButtonDown("Jump") && isGround)
        if (Input.GetMouseButtonDown(0) && isGround)
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }
        
        //if(Input.GetButton("Jump"))
        if (Input.GetMouseButton(0))
            {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
               
            }
        }
        // if(Input.GetButtonUp("Jump"))
        if (Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            
        }
        if(isGround)
        {
            jumpTimeCounter = jumpTime;
           
        }
       

    }
    void CheckGround()
    {
        isGround = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);
       
    }
    void AnimatorPlayer()
    {
        
        playerAnimator.SetBool("ground", isGround);
        playerAnimator.SetBool("play", ManagerSingleton.instance.isPlay);
    }

   

}
