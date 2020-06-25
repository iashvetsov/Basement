using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPush : MonoBehaviour
{
    public float pushForce = 20.0f;
    public int damage = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= damage;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * pushForce, ForceMode2D.Impulse);
        }
    }
}
