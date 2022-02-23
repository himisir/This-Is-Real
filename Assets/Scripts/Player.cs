using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth;
    public float playerStrength;
    public float bulletDamage;
    [Range(.1f, .5f)]
    public float delay;
    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit by Bullet");
            Destroy(other.gameObject, delay);
            playerHealth -= bulletDamage;


        }
    }
    void Health()
    {

    }
    void Strength()
    {

    }
}
