using UnityEngine;
using UnityEngine.UI;


public class HealthBarWithSlider : MonoBehaviour
{
    public Slider healthBar;
    public Player player;

    void Start()
    {
        healthBar.value = player.playerHealth;
    }
    void Update()
    {
        healthBar.value = player.playerHealth;
        healthBar.maxValue = player.playerMaxHealth;
    }
}
