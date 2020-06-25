using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObject : MonoBehaviour
{
    public GameObject fragments;
    public GameObject bonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {   
            Instantiate(fragments, gameObject.transform.position, Quaternion.identity);
            Instantiate(bonus, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
