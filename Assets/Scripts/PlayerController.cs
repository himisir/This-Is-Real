using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float hitDistance;
    public LayerMask layerMask;
    public float jumpForce;
    public bool isGround;
    public float groundCheckRadius;
    public Transform groundCheckObject;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        GroundCheck();
        Jump();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + x * moveSpeed, transform.position.y);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void GroundCheck()
    {
        isGround = false;
        Collider2D colliders = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, layerMask);
        if (colliders != null)
        {
            isGround = true;
        }
    }
}
