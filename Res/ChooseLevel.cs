using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public string sceneName;
    public GameObject loadingScreen;

    public int levelNumber;

    public bool notImage;

    public void LoadLevel()
    {
        StartCoroutine(LoadScene());
        //PlayerPrefs.SetInt("levelNumber", 1);
    }

    IEnumerator LoadScene()
    {
        //PlayerPrefs.SetInt("DoorNumber", 0);
        if (PlayerPrefs.GetInt("levelNumber") >= levelNumber)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            if (!operation.isDone)
            {
                loadingScreen.SetActive(true);
                yield return null;
            }
            else
            {
                loadingScreen.SetActive(true);
            }
        }
    }

    private void Start()
    {
        if(!notImage){
        if (PlayerPrefs.GetInt("levelNumber") >= levelNumber)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        }
    }
}
