using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector2 minPos;
    public Vector2 maxPos;
    public Vector2 offset;
    public float zDistance;
    // Start is called before the first frame update
    void Start()
    {
        //zDistance = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}
