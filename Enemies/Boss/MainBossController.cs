using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossController : MonoBehaviour
{   
    MainBoss mainBoss; //Add Mainboss class
    Animator animator; //animator of main boss
    float timer;
    public float timerRange = 8;
    public GameObject bullet;
    public Transform bulTrans;
    public float moveSpeed = 3;
    public bool facingRight;

    Vector3 newPos;
    public Vector3 posUR, posDR, posDL, posUL;
    float posTimer;
    void Start()
    {
        mainBoss = GetComponent<MainBoss>();
        animator = GetComponent<Animator>();

        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Boss is attacked
        animator.SetBool("isAttacked", mainBoss.isAttacked);
        //Boss Attacks
        float timermax = Random.Range(4, timerRange);
        timer += Time.deltaTime;
        if(timer >= timermax)
        {
            Attack();
            timer = 0;
        }
        //moove boss
        posTimer += Time.deltaTime;
        if(posTimer >= 10){
            newPos = posDR;
        }
        if(posTimer >= 11){
            newPos = posDL;
            if(!facingRight){
                Flip();
            }
        }
        if(posTimer >= 12){
            newPos = posUL;
        }
        if(posTimer >= 22){
            newPos = posDL;
        }
        if(posTimer >= 23){
            newPos = posDR;
            if(facingRight){
                Flip();
            }
        }
        if(posTimer >= 24){
            newPos = posUR;
        }
        if(posTimer >= 25){
            posTimer = 0;
        }
        MoveBoss(newPos);

        //boss dead
        animator.SetBool("Dead", mainBoss.bossIsDead);
    }

    public void Attack()//Set attack bool in animator to true
    {
        animator.SetBool("Attack", true);
    }

    public void NotAttack()//set attack bool in animator to false
    {
        animator.SetBool("Attack", false);
    }

    public void CreateAttackBullet() //create bullet
    {
        Instantiate(bullet, bulTrans);
    }

    public void Flip() //flip the main boss
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void MoveBoss(Vector3 _newPos)
    {  
        transform.position = Vector3.Lerp(transform.position, _newPos, moveSpeed * Time.deltaTime);
    }
}