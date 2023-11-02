using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed ;
    [SerializeField] private float jumpForce ;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D rb;

    public bool isGround;
    [SerializeField] private LayerMask whatIsGround;
   
    private Collider2D playerCollider;

    private Animator playerAnimator;

    [SerializeField] private AudioSource jump;

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

        //if (Input.GetMouseButtonDown(0) && isGround)
        if (Input.GetButtonDown("Jump") && isGround)
        {
           
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jump.Play();
        }
        //if (Input.GetMouseButton(0)) 
        if (Input.GetButton("Jump"))    
            {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
               
            }
        }
        
        //if (Input.GetMouseButtonUp(0))
        if(Input.GetButtonUp("Jump"))
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
