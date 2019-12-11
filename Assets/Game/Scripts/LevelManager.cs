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
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;

    public GameObject player;

    public GameObject Key;

    bool isPressed = false;

    private void Awake()
    {
        //pausePanel = GameObject.Find("Pause");
       // Player = GameObject.Find("Player");
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
       if(player != null)
        {
            changeHealth(player.GetComponent<PlayerAnimControl>().hitPoints);
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

    void changeHealth(int hitPoints)
    {
        if (H1 != null && H2 != null && H3 != null && Key != null && player != null && pausePanel != null && healthPanel != null)
        {
            if (hitPoints == 3)
            {
                H1.gameObject.SetActive(true);
                H2.gameObject.SetActive(true);
                H3.gameObject.SetActive(true);

            }
            else if (hitPoints == 2)
            {
                H1.gameObject.SetActive(true);
                H2.gameObject.SetActive(true);
                H3.gameObject.SetActive(false);

            }
            else if (hitPoints == 1)
            {
                H1.gameObject.SetActive(true);
                H2.gameObject.SetActive(false);
                H3.gameObject.SetActive(false);
            }
            else if (hitPoints == 0)
            {
                H1.gameObject.SetActive(false);
                H2.gameObject.SetActive(false);
                H3.gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void setKey (bool hasKey)
    {
        if(hasKey == true)
        {
            Key.SetActive(true);
        }
        else
        {
            Key.SetActive(false);
        }
    }

}
