using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedKeyText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            StartCoroutine(DontShowText());
        }
    }

    IEnumerator DontShowText()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
