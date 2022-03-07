using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScreenSpace : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Image healthBar;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Health is: " + player.playerHealth);
        healthBar.fillAmount = Mathf.Clamp(player.playerHealth / player.playerMaxHealth, 0f, player.playerMaxHealth);
    }
}
