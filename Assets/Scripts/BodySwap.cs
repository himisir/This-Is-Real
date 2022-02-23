using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwap : MonoBehaviour
{

    // Start is called before the first frame update
    public LayerMask layerMask;
    [Range(.5f, 5)]
    public float morphDuration;
    public GameObject player;
    float countDown;
    GameObject go, copy;
    bool isMorphed;

    void Start()
    {
        countDown = morphDuration;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMorphed)
        {
            countDown -= Time.deltaTime;
        }
        if (countDown <= 0)
        {
            isMorphed = false;
            countDown = morphDuration;
            player.SetActive(true);
            //Instantiate(player, go.transform.position, go.transform.rotation);
            Destroy(go);


        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 worldPoint = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hitInfo.collider != null)
            {
                Debug.Log(hitInfo.collider.name);

                if (hitInfo.collider.tag == "HP" || hitInfo.collider.tag == "Poison Plant" || hitInfo.collider.tag == "Turret")
                {
                    //copy = player;
                    Debug.Log("Swap Initiated");
                    go = Instantiate(hitInfo.collider.gameObject, gameObject.transform.position, gameObject.transform.rotation);

                    player.SetActive(false); //For health Freeze
                    //Destroy(player); //For health reset; 
                    isMorphed = true;
                    countDown = morphDuration;
                }
            }
        }
    }
}
