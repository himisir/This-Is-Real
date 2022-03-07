
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{


    [Range(0, 100)]
    public float bulletSpeed = 5;
    [Range(0, 100)]
    public float maxTravelDistance = 5;
    Rigidbody2D rb;
    Vector2 initialPosition;


    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    void Update()
    {

        if (maxTravelDistance <= Vector2.Distance(initialPosition, transform.position))
        {

            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != null)
        {

            if (other.gameObject.tag == "Tower" || other.gameObject.tag == "Poison Plant" || other.gameObject.tag == "Creep")
            {
                Debug.Log(other.gameObject.tag);
                Destroy(gameObject);
            }
        }
    }
}
