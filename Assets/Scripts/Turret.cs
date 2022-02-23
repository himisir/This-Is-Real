using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate;
    public Transform bullet;
    public float bulletSpeed;
    public bool fire;
    public float hitDistance;
    public LayerMask layerMask;
    void Start()
    {
        StartCoroutine(Fire());

    }

    // Update is called once per frame
    void Update()
    {
        LookForEnemy();
        Bullet();

    }
    void Bullet()
    {

    }
    IEnumerator Fire()
    {
        while (true)
        {
            //Workout hwo to shoot at target
            if (fire) Instantiate(bullet, transform.position, transform.rotation);
            //bullet.localScale *= -1;
            yield return new WaitForSeconds(fireRate);
        }

    }

    void LookForEnemy()
    {
        Debug.DrawRay(transform.position, Vector2.right * hitDistance);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, hitDistance, layerMask);

        if (hitInfo.collider != null)
        {
            Debug.Log("Hit " + hitInfo.collider.tag);
            if (hitInfo.collider.tag == "Player")
            {
                fire = true;
                Debug.Log("Hit " + hitInfo.collider.tag);

            }

        }
        else fire = false;
        //Code for shooting. 
    }

}


