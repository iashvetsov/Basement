using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int damage;
    public float force = 10;
    public float k = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().health -= damage;
            if (!collision.GetComponent<Player>().isAttacked)
            {
                if (collision.transform.localScale.x > 0)
                {
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, force * k), ForceMode2D.Impulse);
                }
                else if (collision.transform.localScale.x < 0)
                {
                    collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, force * k), ForceMode2D.Impulse);
                }
            }
            collision.GetComponent<Player>().isAttacked = true;
        }
    }
}
