using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public static bool isDead;
    public static bool isWin;
    public float playerHealth = 100;
    public float playerMaxHealth = 100;
    public float playerStrength;
    public float bulletDamageTurret;
    public float bulletDamageCreep;
    public float bulletDamagePlayer;
    public float poisonDamage;
    public bool inPoisonRange;
    public float plusHealth;

    public HealthBar healthBar;



    public float hp, st;
    float distance;
    [Range(.1f, 1f)]
    public float physiqueUpdateDelay;

    public bool p1, p2, p3, p4, p5, p6, p7;
    public float creepHpPlus;



    void Start()
    {
        healthBar.SetHeathBar(playerHealth, playerMaxHealth);

        StartCoroutine(Physique());
    }


    //Check if they entered poisonRange; 

    private void OnTriggerEnter2D(Collider2D other)
    { ///<summery>
      ///Artifacts collection and seting certian variable as true
        ;

        if (other.gameObject != null)
        {
            Debug.Log(other.gameObject.name);
            {
                if (other.gameObject.tag == "1")
                {
                    p1 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 1;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "2")
                {
                    p2 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 2;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "3")
                {
                    p3 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 3;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "4")
                {
                    p4 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 4;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "5")
                {
                    p5 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 5;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "6")
                {
                    p6 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 6;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "7")
                {
                    p7 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerHealth += plusHealth;
                    playerMaxHealth += plusHealth;
                    bulletDamagePlayer += 7;
                    Destroy(other.gameObject);

                }
                if (other.gameObject.tag == "Firming")
                {
                    playerHealth += creepHpPlus;
                    bulletDamagePlayer += 10 / creepHpPlus;

                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "Key")
                {
                    bulletDamageTurret += 2;
                    bulletDamageCreep += 2;
                    poisonDamage += 2;
                    playerHealth += plusHealth * 3;
                    playerMaxHealth += plusHealth * 3;
                    bulletDamagePlayer += 20;
                    Destroy(other.gameObject);

                }
            }

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
        if (other.gameObject.tag == "Win")
        {
            isWin = true;
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
        if (playerHealth <= 0)
        {
            isDead = true;
            Time.timeScale = 0;
        }

    }
}
