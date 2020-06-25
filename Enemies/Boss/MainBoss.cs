using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBoss : MonoBehaviour
{
    public GameObject levelCompleteMenu;
    public GameObject tail;
    public int bossHealth = 100; //Boss health
    public Slider bossHealthSlider; //Boss health slider
    public bool bossIsDead; //Dead flag
    public bool isAttacked; //Boss is attacked flag
    void Start(){
        levelCompleteMenu.SetActive(false);
    }
    void Update()
    {
        //Show boss health value in slider
        if(bossHealth > 0)
            bossHealthSlider.value = bossHealth;

        //Set isAttacked to false
        if (isAttacked)
        {
            StartCoroutine(IsAttackedToFalse());
        }

        if(bossHealth <= 0){
            bossHealth = 0;
            bossHealthSlider.value = 0;
            bossHealthSlider.gameObject.SetActive(false);
            bossIsDead = true;
        }
    }

    //Set isAttacked to false Coroutine
    IEnumerator IsAttackedToFalse()
    {
        yield return new WaitForSeconds(0.3f);
        isAttacked = false;
    }
    //Destroy main boss object
    public void MainBossDead(){
        tail.SetActive(false);
        levelCompleteMenu.SetActive(true);
        Destroy(gameObject);
    }

    public void PlayMusicComplete(){
        PlayerMoovement player = FindObjectOfType<PlayerMoovement>();
        player.audioSource.PlayOneShot(player.a_lvlComplete);
    }
}
