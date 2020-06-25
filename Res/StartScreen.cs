using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class StartScreen : MonoBehaviour
{
    private void Start()
    {
        /*if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3389834", false);
        }
        */
    }
    public void LoadLevelsScene()
    {
        /*if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        */
        if(PlayerPrefs.GetString("ShowPrologue") == "true"){
            SceneManager.LoadScene("Prologue");
        }
        else if(PlayerPrefs.GetString("ShowPrologue") == "false"){
            SceneManager.LoadScene("Levels");
        }
        
    }
}
