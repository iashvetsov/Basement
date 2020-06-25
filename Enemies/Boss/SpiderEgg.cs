using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEgg : MonoBehaviour
{
    public GameObject spider;
    
    public int healthCounter = 2;
    float createSpiderTimer = 4.0f;
    bool isAttacked;
    bool isDead;
    bool isSpiderCreated;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon" && !isAttacked)
        {
            healthCounter--;
            isAttacked = true;
        }
    }

    void Update()
    {
        //Dead trigger activate
        if(healthCounter <= 0)
        {
            healthCounter = 0;
            isDead = true;
        }

        //Dead animation
        if(isDead)
        {
            animator.SetBool("isDead", true);
        }

        //Attacked animation
        if(isAttacked)
        {
            animator.SetBool("isAttacked", true);
            StartCoroutine(Attacked());
        }
        else
        {
            animator.SetBool("isAttacked", false);
        }

        //Instantiate timer
        createSpiderTimer -= Time.deltaTime;
        if(createSpiderTimer <= 0 && !isSpiderCreated)
        {
            isDead = true;
            CreateSpider(spider, gameObject.transform);
            isSpiderCreated = true;
        }
    }

    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacked = false;
    }

    public void EggDead()
    {
        Destroy(gameObject);
    }

    void CreateSpider(GameObject spider, Transform spiderTransform)
    {
        Instantiate(spider, spiderTransform.position, Quaternion.identity);
    }
}
