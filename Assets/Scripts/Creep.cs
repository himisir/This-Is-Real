using System.Runtime.CompilerServices;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour
{
    // Start is called before the first frame update
    public float creepHealth = 100;
    public float creepMaxHealth = 100;
    public float speed;
    public Player playerScript;
    public HealthBar healthBar;
    public Transform artifact;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform player;
    public float horizontal, vertical;
    public bool up;
    Vector2 currentPos;
    Vector2 movement;
    bool flag;
    void Start()
    {
        healthBar.SetHeathBar(creepHealth, creepMaxHealth);
        currentPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        if (!up) rb.velocity = transform.right * speed;
        else rb.velocity = transform.up * speed;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Creep Health " + creepHealth);
        healthBar.SetHeathBar(creepHealth, creepMaxHealth);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        if (creepHealth <= 0) Die();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Bullet")
        {
            creepHealth -= playerScript.bulletDamagePlayer;
        }
    }

    void Die()
    {
        if (!flag)
        {
            Instantiate(artifact, transform.position, transform.rotation);
            flag = true;
        }

        Destroy(gameObject);
    }
}
