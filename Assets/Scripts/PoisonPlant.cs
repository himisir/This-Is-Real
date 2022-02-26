using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    public float poisonPlantHealth=100;
    public float poisonPlantMaxHealth=100;
    public Player playerScript;
    public HealthBar healthBar;
    CircleCollider2D sphereCollider;
    [Range(0, 100)]
    public float killRadius;
    void Start()
    {
        healthBar.SetHeathBar(poisonPlantHealth, poisonPlantMaxHealth);
        playerScript = GetComponent<Player>();
        sphereCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHeathBar(poisonPlantHealth, poisonPlantMaxHealth);
        if (poisonPlantHealth <= 0) Die();
        sphereCollider.radius = killRadius;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, killRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Bullet")
        {
            poisonPlantHealth -= playerScript.bulletDamagePlayer;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
