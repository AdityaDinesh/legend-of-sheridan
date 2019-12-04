using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button button;
    public GameObject pausePanel;
    public GameObject healthPanel;
    bool isPressed = false;

    private void Awake()
    {
        //pausePanel = GameObject.Find("Pause");
        //healthPanel = GameObject.Find("Health");

    }

    public void Update()
    {
        if(Input.GetButtonUp("pause"))
        {
            if(isPressed != true)
            {
                PauseLevel(1);
                isPressed = true;
            }
            else
            {
                PauseLevel(0);
                isPressed = false;

            }

        }
    }
    private void Start()
    {
        button.Select();
    }
    public void Play()
    {
        SceneManager.LoadScene("OverWorld");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void reStart()
    {
        SceneManager.LoadScene("OverWorld");
    }

    public void QuitLevel()
    {
        Application.Quit();
    }
    public void Restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void ContinueLevel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseLevel(int val)
    {
        //Time.timeScale = 0;
        //pausePanel.SetActive(true);
        if (val == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else if (val == 0)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }

}
