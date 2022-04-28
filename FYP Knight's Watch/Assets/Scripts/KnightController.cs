//Reference - https://www.youtube.com/watch?v=QGDeafTx5ug
//Reference for dust particles on jump - https://www.youtube.com/watch?v=1CXVbCbqKyg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    public ParticleSystem dustParticle;
    public Animator animator;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D krb;

    private bool fRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;



    void Start()
    {
        extraJumps = extraJumpValue;

        krb = GetComponent<Rigidbody2D>();

       

    }

    void FixedUpdate() //Used for Physics of game
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveInput));



        krb.velocity = new Vector2(moveInput * speed, krb.velocity.y);

        if (fRight == false && moveInput > 0)
        {
            flip();
        } else if(fRight == true && moveInput < 0)
        {
            flip();
        }

    }

    void Update()
    {

        

      
        if (isGrounded == true)
        {
            
            extraJumps = extraJumpValue;
            
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            CreateDust();
            SoundManagerScript.PlaySound ("Jump");
            animator.SetTrigger("Jump");
            krb.velocity = Vector2.up * jumpForce;
            extraJumps--;

            

        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            SoundManagerScript.PlaySound("Jump");
            krb.velocity = Vector2.up * jumpForce;
        }
    }

    void flip()
    {
       
        fRight = !fRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void CreateDust()
    {
        dustParticle.Play();
    }
}
