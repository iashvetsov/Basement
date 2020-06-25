using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            rigidbody2D.gravityScale = 1;
            StartCoroutine(DestroyObject());
        }
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
