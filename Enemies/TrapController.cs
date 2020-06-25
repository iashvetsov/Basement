using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    
    bool flip;
    public bool Right;

    public float time = 1.0f;
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            flip = !flip;
            timer = 0;
        }
        if (flip)
        {
            if (Right)
            {
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Right)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
        }
    }
}
