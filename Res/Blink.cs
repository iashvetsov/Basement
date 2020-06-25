using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    float timer;
    bool isBlink;

    public Player player;

    void Update()
    {   
         BlinkActivate(player.GetIsAttacked());
    }

    void BlinkActivate(bool isAttacked)
    {
        if (isAttacked)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                isBlink = !isBlink;
                timer = 0;
            }
            if (isBlink)
            {
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
}
