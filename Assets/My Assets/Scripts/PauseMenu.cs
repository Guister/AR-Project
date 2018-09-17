using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public static bool paused = false;
    public GameObject pauseMenuUI;
    public GameObject restartMenuUI;


    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            if(paused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
	}

    public void Pause()
    {
        paused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        SideMove.timeDelta = 0;
    }

    public void Resume()
    {
        paused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SideMove.timeDelta = 0.2f;      
    }

    public void Restart()
    {
        paused = false;
        Time.timeScale = 1;
        SideMove.timeDelta = 0.2f;
        ScoreScript.scoreValue = 0;
        Spawner.obstaclesSpawned = 0;
        SceneManager.LoadScene("GroundPlane");
        Spawner.clicked = false;
        RestartMenu.lost = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
