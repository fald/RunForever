using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int numJumps;
    public int maxJumps;

    public bool grounded;
    public LayerMask groundLayer;

    // Collider as opposed to box collider for generalization
    private Collider2D myCollider;

    private Rigidbody2D myRigidBody; // ;)

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        numJumps = maxJumps;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        if (grounded)
        {
            numJumps = maxJumps;
        }

        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (numJumps > 0))
        {
            numJumps--;
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
    }
}
