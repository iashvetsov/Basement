using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevels : MonoBehaviour
{
    public void LoadLevelsScene(){
        SceneManager.LoadScene("Levels");
        PlayerPrefs.SetString("ShowPrologue", "false");
    }
}
