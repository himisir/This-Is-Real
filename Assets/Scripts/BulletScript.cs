using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;

    void FixedUpdate()
    {
        transform.Translate(transform.position * bulletSpeed * Time.deltaTime, Space.World);
        //transform.position = new Vector2(transform.position.x + bulletSpeed * Time.deltaTime, transform.position.y);
    }

}
