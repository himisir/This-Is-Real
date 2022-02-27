using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawnManager : MonoBehaviour
{
    public Transform creep;
    bool flag;

    public float delay;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (!flag)
            {
                yield return new WaitForSeconds(delay);

            }
            FlagCheck();
            Instantiate(creep, transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);

        }


        void FlagCheck()
        {
            this.flag = false;
            Player player = FindObjectOfType<Player>();
            if (gameObject.tag == "1") this.flag = true;
            if (player.p1 && gameObject.name == "2")
            {
                this.flag = true;
            }
            if (player.p2 && gameObject.tag == "3")
            {
                this.flag = true;
            }
            if (player.p3 && gameObject.tag == "4")
            {
                this.flag = true;
            }
            if (player.p4 && gameObject.tag == "5")
            {
                this.flag = true;
            }
            if (player.p5 && gameObject.tag == "6")
            {
                this.flag = true;
            }

        }



    }

}
