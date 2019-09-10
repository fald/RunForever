using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int numJumps;
    public int maxJumps;

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

    void FixedUpdate()
    {
        prevGrounded = grounded;
        grounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        if (!prevGrounded && grounded)
        {
            numJumps = 0;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && 
            // attempt at fixing that damn bug
            //(grounded || (!grounded && numJumps < maxJumps && numJumps > 0)))
            (numJumps < maxJumps))
        {
            numJumps++;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }

        myAnimator.SetFloat("Speed", moveSpeed);
        myAnimator.SetBool("Grounded", grounded);
    }
}
