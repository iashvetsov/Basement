using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private static int counterAdv = 0;
    
    void Start()
    {
        pauseMenu.SetActive(false);
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3389834", false);
        }
    }

    public void GetPause()
    {
        Time.timeScale = 0;
        ShowPaused(true);
    }

    public void Resume()
    {
        ShowPaused(false);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Advertisement.IsReady() && counterAdv % 3 == 0)
        {
            Advertisement.Show();
        }
        counterAdv++;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    void ShowPaused(bool setValue)
    {
        pauseMenu.SetActive(setValue);
    }
}
