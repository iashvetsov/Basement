using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMute : MonoBehaviour
{
    void Update()
    {
        if (PlayerPrefs.GetString("Music") == "on")
        {
            GetComponent<AudioListener>().enabled = true;
        }
        else if (PlayerPrefs.GetString("Music") == "off")
        {
            GetComponent<AudioListener>().enabled = false;
        }
    }
}
