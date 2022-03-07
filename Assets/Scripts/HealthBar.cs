using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Player player;
    public Color min;
    public Color max;

    public void SetHeathBar(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;
        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(min, max, slider.normalizedValue);
    }
    


}
