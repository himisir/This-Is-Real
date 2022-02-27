using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       // GameCheck();
    }
    void GameCheck()
    {
        Player player = FindObjectOfType<Player>();

        Debug.Log(player.p1);
        Debug.Log(player.p2);
        Debug.Log(player.p3);
        Debug.Log(player.p4);
        Debug.Log(player.p5);
        Debug.Log(player.p6);

    

    }
}
