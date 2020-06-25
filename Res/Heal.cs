using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int addHealth;
    AudioSource audioSource_puckupSoul;
    public AudioClip a_pickSoul;
    void Start()
    {
        audioSource_puckupSoul = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource_puckupSoul.PlayOneShot(a_pickSoul);
            collision.gameObject.GetComponent<Player>().health += addHealth;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyHeal());
        }
    }
    IEnumerator DestroyHeal(){
        yield return new WaitForSeconds(0.436f);
        Destroy(gameObject);
    }
}
