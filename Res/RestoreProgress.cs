using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestoreProgress : MonoBehaviour
{
    public GameObject restoreMenu;

    private void Start()
    {
        restoreMenu.SetActive(false);
    }

    public void ShowRestoreMenu()
    {
        restoreMenu.SetActive(true);
    }

    public void CancelRestore()
    {
        restoreMenu.SetActive(false);
    }

    public void RestoreGameProgress()
    {
        PlayerPrefs.SetInt("levelNumber", 1);
        PlayerPrefs.SetInt("DoorNumber", 0);
        PlayerPrefs.SetString("ShowPrologue", "true");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //restoreMenu.SetActive(false);
    }
}
