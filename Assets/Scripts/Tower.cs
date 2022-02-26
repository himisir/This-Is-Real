using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public HealthBar healthBar;
    public Player player;
    float turretHealth;
    public float turretMaxHealth;

    void Start()
    {
        turretHealth = turretMaxHealth;
        healthBar.SetHeathBar(turretHealth, turretMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHeathBar(turretHealth, turretMaxHealth);
        if (turretHealth <= 0) Die();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Bullet")
        {
            turretHealth -= player.bulletDamagePlayer;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }


}
