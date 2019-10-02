using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Set central quite/restart, this is dumb and wet.
public class PauseMenu : MonoBehaviour
{
    public string mainSceneName;
    public GameManager gm;
    public GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pauseMenu.activeSelf)
        {
            ResumeGame();
        } else
        {
            PauseGame();
        }
    }

    public void restart()
    {
        ResumeGame();
        gm.Reset();
    }

    public void quitToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(mainSceneName);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
