using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    int step;

    public float time = 1.0f;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            step++;
            timer = 0;
        }
        if(step > 3)
        {
            step = 0;
        }
        switch (step) {
            case 0:
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
                break;
        }
        
    }
}
