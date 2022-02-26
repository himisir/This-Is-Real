
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float turretHealth = 100;
    public float turretMaxHealth = 100;
    //public Player player;
    //public HealthBar healthBar;
    public float fireRate;

    public Transform bullet;
    public Transform barrelTip;
    public float bulletSpeed;
    public bool fire;
    public float hitDistance;
    public LayerMask layerMask;
    void Start()
    {
        //healthBar.SetHeathBar(turretHealth, turretMaxHealth);
        //player = GetComponent<Player>();
        StartCoroutine(Fire());

    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.SetHeathBar(turretHealth, turretMaxHealth);
        LookForEnemy();
        Bullet();
        if (turretHealth <= 0) Die();

    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Bullet()
    {

    }
    IEnumerator Fire()
    {
        while (true)
        {
            //Workout hwo to shoot at target
            if (fire) Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            yield return new WaitForSeconds(fireRate);
        }

    }

    void LookForEnemy()
    {

        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, hitDistance, layerMask); //Add layerMask if does not work
        if (hitInfo != null && hitInfo.tag == "Player")
        {
            fire = true;
            transform.right = (hitInfo.transform.position - transform.position);
            Debug.DrawRay(transform.position, transform.right * Vector2.Distance(transform.position, hitInfo.transform.position), Color.red);

        }
        else fire = false;


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitDistance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Bullet")
        {
            //turretHealth -= player.bulletDamagePlayer;
        }
    }

}


