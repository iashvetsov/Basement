using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialButton : MonoBehaviour
{
    public string url;

    public void GoToUrl(){
        Application.OpenURL(url);
    }
}
