using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPlant : MonoBehaviour
{
    CircleCollider2D sphereCollider;
    [Range(0, 100)]
    public float killRadius;
    void Start()
    {
        sphereCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sphereCollider.radius = killRadius;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, killRadius);
    }
}
