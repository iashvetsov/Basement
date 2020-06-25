using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public bool isDead;

    public GameObject blood;
    public Transform bloodPos;

    public bool isAttacked;

    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            isDead = true;
        }
        if (isAttacked)
        {
            StartCoroutine(IsAttackedToTrue());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Instantiate(blood, bloodPos);
        }
    }

    IEnumerator IsAttackedToTrue()
    {
        yield return new WaitForSeconds(0.3f);
        isAttacked = false;
    }
}
