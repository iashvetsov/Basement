using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIsDead : MonoBehaviour
{
    Boss boss;
    public List <GameObject> objects;
    void Start()
    {
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss.bossHealth <= 0){
            foreach(var obj in objects){
                obj.SetActive(false);
            }
        }
    }
}
