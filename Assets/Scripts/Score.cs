using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Player player;
    void Update()
    {
        score.text = "Score: " + player.creepKillCount.ToString();
    }
}
