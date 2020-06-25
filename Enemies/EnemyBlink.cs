using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlink : MonoBehaviour
{
    public List<SpriteRenderer> spriteList;

    EnemyHealth enemyHealth;
    bool isBlink = true;
    float timer;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

        List<Transform> ret = new List<Transform>();
        foreach (Transform child in transform)
        {
            foreach(Transform item in child)
            {
                ret.Add(item);
            }
            ret.Add(child);
        }
        ret.ToArray();


        foreach (var item in ret)
        {
            if (item.GetComponent<SpriteRenderer>() != null)
            {
                spriteList.Add(item.GetComponent<SpriteRenderer>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Blink();
    }

    void Blink()
    {
        if (enemyHealth.isAttacked)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                isBlink = !isBlink;
                timer = 0;
            }
            if (isBlink)
            {
                foreach(var sprite in spriteList)
                {
                    sprite.color = new Color(255, 255, 255, 255);
                }
            }
            else
            {
                foreach (var sprite in spriteList)
                {
                    sprite.color = new Color(255, 255, 255, 0);
                }
            }
        }
        else
        {
            foreach (var sprite in spriteList)
            {
                sprite.color = new Color(255, 255, 255, 255);
            }
        }
    }
}
