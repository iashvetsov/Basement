using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyHealth>().isAttacked == false)
            {
                collision.GetComponent<EnemyHealth>().health -= damage;
                collision.GetComponent<EnemyHealth>().isAttacked = true;
            }
        }
        if(collision.gameObject.tag == "Boss")
        {
            if(collision.GetComponent<Boss>().isAttacked == false)
            {
                collision.GetComponent<Boss>().bossHealth -= damage;
                collision.GetComponent<Boss>().isAttacked = true;
            }
        }
        if(collision.gameObject.tag == "MainBoss")
        {
            if(collision.GetComponent<MainBoss>().isAttacked == false)
            {
                collision.GetComponent<MainBoss>().bossHealth -= damage;
                collision.GetComponent<MainBoss>().isAttacked = true;
            }
        }
    }
}
