using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float bulletSpeed = 5;
    public Player player;
    Rigidbody2D rb;
    Vector2 initialPosition;
    public float maxTravelDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxTravelDistance <= Vector2.Distance(initialPosition, transform.position))
        {
            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tower" || other.gameObject.tag == "Poison Plant" || other.gameObject.tag == "Creep")
        {
            Destroy(gameObject);
        }
    }
}
