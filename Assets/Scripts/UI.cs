using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    Button restartButton;
    public GameObject win;
    public GameObject dead;
    Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton = GetComponent<Button>();
        exitButton = GetComponent<Button>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }

        if (Player.isDead)
        {
            Time.timeScale = 0;

            dead.SetActive(true);
        }
        else if (Player.isWin)
        {
            Time.timeScale = 0;
            win.SetActive(true);

        }


    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
