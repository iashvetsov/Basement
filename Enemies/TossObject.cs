using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossObject : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 10;
    public int direction = -1;

    public float x1, x2, y1, y2;

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        float forceX, forceY;
        forceX = Random.Range(x1, x2);
        forceY = Random.Range(y1, y2);
        rb.AddForce(new Vector2(direction * forceX, forceY), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        if (collision.gameObject.tag != "Enemy")
        {
            animator.SetBool("Destroy", true);
        }
    }

    public void DestroyTossObject()
    {
        Destroy(gameObject);
    }
}
