using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject creatingObject;
    float timer;
    float timerMax;
    public float minRange, maxRange;
    void Update()
    {
        timerMax = Random.Range(minRange , maxRange);

        timer += Time.deltaTime;
        if(timer >= timerMax){
            timer = 0;
            Instantiate(creatingObject, transform.position, Quaternion.identity);
        }
    }
}
