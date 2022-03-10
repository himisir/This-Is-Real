using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static bool isGameRunning;
    public Player player;
    Button startButton;
    Button exitButton;
    Button restartButton;
    Button resumeButton;

    public GameObject winNote;
    public GameObject deadNote;
    public GameObject start;
    public GameObject restart;
    public GameObject pause;
    public GameObject background;
    public bool isGameRestart;

    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = false;
        background.SetActive(true);
        startButton = GetComponent<Button>();
        exitButton = GetComponent<Button>();
        restartButton = GetComponent<Button>();
        resumeButton = GetComponent<Button>();
        start.SetActive(true);
    }
    void Update()
    {
        Debug.Log("IsGameRunning is " + isGameRunning);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (player.isDead)
        {
            deadNote.SetActive(true);
            Default();
        }
        else if (player.isWin)
        {
            winNote.SetActive(true);
            Default();
        }
    }

    public void Default()
    {
        isGameRunning = false;
        background.SetActive(true);
        if (isGameRestart)
        {
            restart.SetActive(true);
        }
        else start.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void StartGame()
    {
        background.SetActive(false);
        isGameRunning = true;
        isGameRestart = true;
        start.SetActive(false);
        restart.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        background.SetActive(true);
        pause.SetActive(true);
        isGameRunning = false;
    }
    public void Resume()
    {
        background.SetActive(false);
        isGameRestart = true;
        isGameRunning = true;
        pause.SetActive(false);
    }

}
