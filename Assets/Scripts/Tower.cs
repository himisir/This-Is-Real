using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public HealthBar healthBar;
    public Transform artifact;
    public Transform point;
    public Player player;
    float turretHealth;
    bool flag;
    public float turretMaxHealth;

    void Start()
    {
        turretHealth = turretMaxHealth;
        healthBar.SetHeathBar(turretHealth, turretMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GameCheck();
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
    void GameCheck()
    {
        /*
        Debug.Log(point.gameObject.tag);
        point.gameObject.SetActive(player.p1 && gameObject.name == "2");
        point.gameObject.SetActive(player.p2 && gameObject.tag == "3");
        point.gameObject.SetActive(player.p3 && gameObject.tag == "4");
        point.gameObject.SetActive(player.p4 && gameObject.tag == "5");
        point.gameObject.SetActive(player.p5 && gameObject.tag == "6");
        */
      
    }
    void Die()
    {
        if (!flag)
        {
            Instantiate(artifact, point.transform.position, point.transform.rotation);
            flag = true;
        }

        Destroy(gameObject);
    }


}
