using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public PlayerTrigger trigger;
    Animator animator;
    public GameObject instantiateObject;
    public Transform tossPosition;
    EnemyHealth health;
    bool Attack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        Attack = trigger.OnTrigger;
        animator.SetBool("Attack", Attack);

        if (health.isAttacked)
        {
            animator.SetBool("isAttacked", true);
        }
        else
        {
            animator.SetBool("isAttacked", false);
        }

        if (health.isDead)
        {
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1.5f);
        }
    }

    public void Toss()
    {
        Instantiate(instantiateObject, tossPosition);
    }
}
