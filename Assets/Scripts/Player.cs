using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float creepKillDamageGain;

    public HealthBar healthBar;
    public int creepKillCount;



    public float hp, st;
    float distance;
    [Range(.1f, 1f)]
    public float physiqueUpdateDelay;

    public bool p1, p2, p3, p4, p5, p6, p7;
    public float creepHpPlus;



    void Start()
    {
        healthBar.SetHeathBar(playerHealth, playerMaxHealth);

        //StartCoroutine(Physique()); //Disabled for now
    }




    ///<summery>
    ///Following section is for checking triggers and setting health/damage value based on that. 
    ///</summery>


    private void OnTriggerEnter2D(Collider2D other)
    {
        ///<summery>
        ///Health and Damage management
        ///</summery>

        if (other.gameObject != null)
        {
            //Debug.Log(other.gameObject.name);
            {
                if (other.gameObject.tag == "1")
                {
                    p1 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;

                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 1;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "2")
                {
                    p2 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 2;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "3")
                {
                    p3 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 3;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "4")
                {
                    p4 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 4;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "5")
                {
                    p5 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
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
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 6;
                    Destroy(other.gameObject);
                }
                if (other.gameObject.tag == "7")
                {
                    p7 = true;
                    bulletDamageTurret++;
                    bulletDamageCreep++;
                    poisonDamage += 0.3f;
                    playerMaxHealth += plusHealth;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 7;
                    Destroy(other.gameObject);

                }
                if (other.gameObject.tag == "Firming")
                {
                    if (playerHealth <= playerMaxHealth) playerHealth += creepHpPlus;
                    bulletDamagePlayer += creepKillDamageGain / creepHpPlus;
                    creepKillCount++;
                    Destroy(other.gameObject);
                }


                if (other.gameObject.tag == "Key")
                {
                    bulletDamageTurret += 2;
                    bulletDamageCreep += 2;
                    poisonDamage += 2;
                    playerMaxHealth += plusHealth * 3;
                    playerHealth = playerMaxHealth;
                    bulletDamagePlayer += 20;
                    Destroy(other.gameObject);

                }
                if (other.gameObject.tag == "Win")
                {
                    isWin = true;
                }
            }


            ///<summery>
            ///Power up machanism is disable for now
            ///</summery>

            /*
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
            */


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
            /*

            if (other.gameObject.tag == "Poison Plant")
            {
                distance = Vector2.Distance(transform.position, other.gameObject.transform.position);
            }
            */


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
            PoisonDamage();


        }
    }

    ///<summary>
    ///Poison Plant damage management
    ///</summary>

    //Check if they left poisonRange; 
    /*    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Poison Plant")
        {
            inPoisonRange = false;
        }
    }
    */

    ///<summary>
    /// Physique()
    ///Take care of player health and strength
    ///But it is obsolete now
    ///</summary>
    ///<pram name = "physiqueUpdateDelay"> </param>

    /*
        IEnumerator Physique()
        {
            while (true)
            {
                PoisonDamage();
                Strength();

                yield return new WaitForSeconds(physiqueUpdateDelay);
            }
        }

        */

    ///<summary>
    ///Increase HP and ST by hp and st, may not use it
    ///</summery>
    /*  
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
    */
    void Die()
    {
        Destroy(gameObject);
    }




    void PoisonDamage()
    {
        if (distance > 0) playerHealth -= poisonDamage / distance; //Increase damage based on distance

    }



    void Strength()
    {
        //Debug.Log("Strength: " + playerStrength);
    }
    void Update()
    {
        healthBar.SetHeathBar(playerHealth, playerMaxHealth);
        if (playerHealth <= 0)
        {
            isDead = true;
        }
    }
}
