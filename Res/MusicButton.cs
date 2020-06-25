using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite mus_on, mus_off;

    void Start()
    {
        //PlayerPrefs.SetString("Music", "on");
        if (PlayerPrefs.GetString("Music") == "on")
        {
            GetComponent<Image>().sprite = mus_on;
        }
        else if (PlayerPrefs.GetString("Music") == "off")
        {
            GetComponent<Image>().sprite = mus_off;
        }
    }

    public void ClickMusicButton()
    {
        if (PlayerPrefs.GetString("Music") == "on")
        {
            PlayerPrefs.SetString("Music", "off");
            GetComponent<Image>().sprite = mus_off;
        }
        else if (PlayerPrefs.GetString("Music") == "off")
        {
            PlayerPrefs.SetString("Music", "on");
            GetComponent<Image>().sprite = mus_on;
        }
    }
}
