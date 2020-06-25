using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    AudioSource audioSource_puckKey;
    public AudioClip a_pickKey;
    void Start()
    {
        audioSource_puckKey = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource_puckKey.PlayOneShot(a_pickKey);
            collision.GetComponent<Player>().haveKey = true;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyKey());
        }
    }

    IEnumerator DestroyKey(){
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
