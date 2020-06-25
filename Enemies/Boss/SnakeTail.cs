using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    Animator animator;
    float timer;
    float timerRange;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        timerRange = Random.Range(2.0f, 4.0f);
        timer += Time.deltaTime;
        if(timer >= timerRange){
            animator.SetBool("Attack", true);
            timer = 0;
        }
        else{
            animator.SetBool("Attack", false);
        }
    }
}
