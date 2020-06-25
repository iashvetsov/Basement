using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{   
    public PlayerMoovement player;
    public GameObject gameOverMenu;

    private static int counterAdv = 0;
    private bool advDone;

    private void Start()
    {
        gameOverMenu.SetActive(false);
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3389834", false);
        }
    }

    void Update()
    {
        if (player.Dead)
        {
            StartCoroutine(GameOverTimer());
        }
        if(player.Dead && !advDone)
        {
            PlayerLoose();
        }
    }

    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(1.0f);
        gameOverMenu.SetActive(true);
    }

    void PlayerLoose()
    {
        if (Advertisement.IsReady() && counterAdv % 5 == 0)
        {
            Advertisement.Show();
        }
        counterAdv++;
        advDone = true;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
}
