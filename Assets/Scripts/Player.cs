using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    public float playerHealth = 100;
    public float playerMaxHealth = 100;
    public float playerStrength;
    public float bulletDamageTurret;
    public float bulletDamageCreep;
    public float bulletDamagePlayer;
    public float poisonDamage;
    public bool inPoisonRange;

    public HealthBar healthBar;



    public float hp, st;
    float distance;
    [Range(.1f, 1f)]
    public float physiqueUpdateDelay;



    void Start()
    {
        healthBar.SetHeathBar(playerHealth, playerMaxHealth);

        StartCoroutine(Physique());
    }


    //Check if they entered poisonRange; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        PowerUP(other);


        ///<summary>
        ///HP and ST management
        ///</summary>

        if (other.gameObject.tag == "HP")
        {
            Destroy(other.gameObject);
            if (playerHealth + hp >= 100) playerHealth = 100;
            else playerHealth += hp;

        }
        if (other.gameObject.tag == "ST")
        {
            Destroy(other.gameObject);
            if (playerStrength + st >= 100) playerStrength = 100;
            else playerStrength += st;
        }


        ///<summary>
        ///Bullet damage management
        ///</summary>

        if (other.gameObject.CompareTag("Turret Bullet"))
        {
            Debug.Log("Hit by Bullet");
            Destroy(other.gameObject);
            playerHealth -= bulletDamageTurret;
        }
        else if (other.gameObject.CompareTag("Creep Bullet"))
        {
            Destroy(other.gameObject);
            playerHealth -= bulletDamageCreep;
        }

        ///<summary>
        /// Poison Plant damage management
        ///</summary>

        if (other.gameObject.tag == "Poison Plant")
        {
            inPoisonRange = true;
            distance = Vector2.Distance(transform.position, other.gameObject.transform.position);

        }
    }

    ///<summary>
    ///Poison Plant damage management
    ///</summary>

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Poison Plant" && inPoisonRange)
        {
            distance = Vector2.Distance(transform.position, other.gameObject.transform.position);
        }
    }



    ///<summary>
    ///Poison Plant damage management
    ///</summary>
    //Check if they left poisonRange; 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Poison Plant")
        {
            inPoisonRange = false;
        }
    }


    ///<summary>
    ///Take care of player health and strength
    ///</summary>
    ///<pram name = "physiqueUpdateDelay"> </param>

    IEnumerator Physique()
    {
        while (true)
        {
            PoisonDamage();
            Strength();

            yield return new WaitForSeconds(physiqueUpdateDelay);
        }
    }

    ///<summary>
    ///Increase HP and ST by hp and st, may not use it
    ///</summery>
    void PowerUP(Collider2D other)
    {

        if (other.gameObject.tag == "HP")
        {
            Destroy(other.gameObject);
            if (playerHealth + hp >= 100) playerHealth = 100;
            else playerHealth += hp;

        }
        if (other.gameObject.tag == "ST")
        {
            Destroy(other.gameObject);
            if (playerStrength + st >= 100) playerStrength = 100;
            else playerStrength += st;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }




    void PoisonDamage()
    {

        if (distance > 0 && inPoisonRange) playerHealth -= poisonDamage / distance; //Increase damage based on distance
        Debug.Log("Health: " + playerHealth);
    }


    
    void Strength()
    {
        Debug.Log("Strength: " + playerStrength);
    }
    void Update()
    {

        healthBar.SetHeathBar(playerHealth, playerMaxHealth);
    }
}
