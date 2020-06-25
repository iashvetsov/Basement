using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public bool isAttacking;

    public float moveSpeed;
    public float distance;
    public bool movingRight = true;

    public Transform groundDetection;

    Animator animator;
    EnemyHealth health;


    bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        isDead = health.isDead;
        if(isDead)
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject, 1.5f);
        }
        else 
        {
            animator.SetBool("isAttack", isAttacking);

            if (!isAttacking)
            {
                animator.SetBool("isWalk", true);

                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

                RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
                if (groundInfo.collider == false)
                {
                    if (movingRight)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            if (collision.tag == "Weapon")
            {
                animator.SetBool("isHit", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.tag == "Weapon")
        {
            animator.SetBool("isHit", false);
        }
    }
}
