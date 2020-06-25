using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpider : MonoBehaviour
{
    Animator animator;
    bool Attack;
    float timer;
    float timerMax = 4;
    public float minRange, maxRange;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack", Attack);

        timerMax = Random.Range(minRange , maxRange);

        timer += Time.deltaTime;
        if(timer >= timerMax){
            timer = 0;
            Attack = true;
        }
    }
    public void SetAttackToFalse(){
        Attack = false;
    }
}
