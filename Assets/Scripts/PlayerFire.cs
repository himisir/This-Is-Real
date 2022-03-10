using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform bullet;
    public Transform barrelTip;

    [Range(0f, 100f)]
    public float bulletSpeed = 5;
    public bool fire;

    [Range(0f, 100f)]
    public float fireRate;
    Vector2 targetPos;
    [Range(0f, 100f)]
    public float hitRadius;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());

    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (fire) Instantiate(bullet, barrelTip.position, barrelTip.rotation);
            fire = false;
            yield return new WaitForSeconds(1 / fireRate);

        }

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(1) && UI.isGameRunning)
        {
            Vector2 pos = Input.mousePosition;
            targetPos = Camera.main.ScreenToWorldPoint(pos);

            transform.right = ((Vector2)transform.position - targetPos) * -1;
            fire = true;
            //Debug.Log(Vector2.Angle(transform.position, targetPos));
            Debug.DrawRay(transform.position, transform.right * (Vector2.Distance(transform.position, targetPos)), Color.red);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, hitRadius);
    }

}
