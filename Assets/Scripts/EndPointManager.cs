using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameOverLimit;
    int sum = 0;
    public bool gameOverBool;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Creep")
        {


            Destroy(other.gameObject);
            sum++;

        }
        if (sum >= gameOverLimit) gameOverBool = true;
    }

    public bool Gameover()
    {
        return gameOverBool;
    }
}
