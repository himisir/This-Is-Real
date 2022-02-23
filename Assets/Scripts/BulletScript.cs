using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    [Range(0, 100)]
    public float maxTravelDistance;
    Vector2 initialPosition;
    Rigidbody2D rb;
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;


    }
    void Update()
    {

        //Destroy object if out of sight
        if (maxTravelDistance <= Vector2.Distance(initialPosition, transform.position))
        {
            Destroy(gameObject);

        }
    }

    //Use Trigger if you finally decide to get rid of that fancy push back from fire! 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player") Destroy(gameObject);
    }



}
