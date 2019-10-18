using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: The jumping code is ugly, fix it.
// TODO: Also add coyote-time to the jumps

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed;
    public float initSpeed;
    public float jumpForce;
    public int numJumps;
    public int maxJumps;
    public float fallMultiplier;
    public float lowFallMultiplier;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    // Point to inc speed
    public float speedIncreaseMilestone;
    // How much to inc speed
    public float speedIncreaseAmount;
    // How far since prev milestone to inc speed
    public float speedIncreaseDistance;
    // Also can have milestone dist increases, or speed multipliers instead of additive, but I won't
    // bother at this point.

    public float jumpTime;
    private float jumpTimeCounter;

    public bool prevGrounded;
    public bool grounded;
    public LayerMask groundLayer;
    private Collider2D myCollider;
    private Rigidbody2D myRigidBody; // ;)
    // Not a fan of the circle, but yeah
    public Transform groundCheck;
    public float groundCheckRadius;

    private Animator myAnimator;

    public bool isInvulnerable;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Awake()
    {
        numJumps = 0;
        grounded = false;
        prevGrounded = false;
        speedIncreaseMilestone = speedIncreaseDistance;
        moveSpeed = initSpeed;
    }

    void Update()
    {
        if (transform.position.x > speedIncreaseMilestone)
        {
            speedIncreaseMilestone += speedIncreaseDistance;
            moveSpeed += speedIncreaseAmount;
        }
        prevGrounded = grounded;
        //grounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (!prevGrounded && grounded)
        {
            numJumps = 0;
            jumpTimeCounter = jumpTime;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        /*
        if (myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime * (fallMultiplier - 1);
        } else if (myRigidBody.velocity.y > 0 && (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)))
        {
            myRigidBody.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime * (lowFallMultiplier - 1);
        }
        */

        Jump();

        myAnimator.SetFloat("Speed", moveSpeed);
        myAnimator.SetBool("Grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "killbox") && (!isInvulnerable))
        {
            deathSound.Play();
            gameManager.RestartGame();
        }
    }

    void Jump()
    {
        // Initial press
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            && (numJumps < maxJumps) 
            && (grounded || (!grounded && numJumps > 0)))
        {
            jumpSound.Play();
            numJumps++;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }

        // Holding
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            && (!grounded)
            && (jumpTimeCounter > 0)
            && (numJumps == 1))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }
        
        // Releasing
        // In this case we stop the spam-jump, and the jump length can only be modified
        // on the first jump in the chain.
        // Don't think its necessary with the update to the holding portion.
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)))
        {
            jumpTimeCounter = 0;
        }
    }
        
}
