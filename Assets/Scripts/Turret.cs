using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate;
    public Transform bullet;
    public Transform barrelTip;
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
            if (fire) Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            //bullet.localScale *= -1;
            yield return new WaitForSeconds(fireRate);
        }

    }

    void LookForEnemy()
    {

        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, hitDistance, layerMask);
        //RaycastHit2D hitInfo = Physics2D.Raycast(barrelTip.position, barrelTip.transform.right, hitDistance, layerMask);

        if (hitInfo != null)
        {
            //Debug.Log("Hit " + hitInfo.tag);
            if (hitInfo.tag == "Player" && Physics2D.Raycast(barrelTip.position, barrelTip.transform.right, hitDistance, layerMask))
            {
                float angle = Vector2.Angle(transform.position, hitInfo.transform.position);
                transform.right = (hitInfo.transform.position - transform.position) * -1; ///Equivalent to lookAt!!!! 
                fire = true;
                Debug.Log(angle + " " + hitInfo.transform.position);
                Debug.DrawRay(transform.position, barrelTip.transform.right * Vector2.Distance(transform.position, hitInfo.transform.position), Color.red);

            }

        }
        else fire = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitDistance);
    }

}


