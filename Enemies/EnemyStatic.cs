using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    EnemyHealth enemyHealth;
    Animator animator;
    public EnemyGun enemyGun;
    

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (enemyHealth.isDead)
        {
            GetComponent<Collider2D>().enabled = false;
            enemyGun.enabled = false;
            animator.SetBool("isDead", true);
            Destroy(gameObject, 1.0f);
        }
    }
}
