using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform bullet;
    public Transform barrelTip;
    public float bulletSpeed;
    public bool fire;
    public float fireRate;
    Vector2 targetPos;
    public float hitDistance;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());

    }

    IEnumerator Fire()
    {
        while (true)
        {
            //Workout hwo to shoot at target
            if (fire) Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            fire = false;
            //bullet.localScale *= -1;
            yield return new WaitForSeconds(fireRate);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 pos = Input.mousePosition;
            targetPos = Camera.main.ScreenToWorldPoint(pos);

            transform.right = ((Vector2)transform.position - targetPos) * -1;
            fire = true;
            Debug.Log(Vector2.Angle(transform.position, targetPos));
            Debug.DrawRay(transform.position, transform.right * (Vector2.Distance(transform.position, targetPos)), Color.red);
        }

    }



    void FollowEnemy()
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(transform.position, hitDistance);
        if (hitInfo != null)
        {

        }
    }
}
