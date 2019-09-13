using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int numJumps;
    public int maxJumps;

    public float jumpTime;
    private float jumpTimeCounter;

    public bool prevGrounded;
    public bool grounded;
    public LayerMask groundLayer;
    private Collider2D myCollider;
    private Rigidbody2D myRigidBody; // ;)

    private Animator myAnimator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        numJumps = 0;
        grounded = false;
        prevGrounded = false;
    }

    void Update()
    {
        prevGrounded = grounded;
        grounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        if (!prevGrounded && grounded)
        {
            numJumps = 0;
            jumpTimeCounter = jumpTime;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        // Initial press
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && 
            // attempt at fixing that damn bug
            //(grounded || (!grounded && numJumps < maxJumps && numJumps > 0)))
            (numJumps < maxJumps))
        {
            numJumps++;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }

        // Holding
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && (!grounded))
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        // Releasing
        // In this case we stop the spam-jump, and the jump length can only be modified
        // on the first jump in the chain.
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)))
        {
            jumpTimeCounter = 0;
        }

            myAnimator.SetFloat("Speed", moveSpeed);
        myAnimator.SetBool("Grounded", grounded);
    }
}
