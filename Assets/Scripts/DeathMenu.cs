using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Both menu scripts are just button scripts....and the same one, to boot.
public class DeathMenu : MonoBehaviour
{
    public string mainSceneName;
    public GameManager gm;

    public void restart()
    {
        gm.Reset();
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(mainSceneName);
    }

}
