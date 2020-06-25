using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMoovement playerMoovement;
    Boss boss;
    MainBoss mainBoss;
    public bool isMainBoss;
    
    AudioSource audioSource;
    bool lvlComplPlay = true;
    void Start()
    {
        playerMoovement = FindObjectOfType<PlayerMoovement>();
        audioSource = GetComponent<AudioSource>();
        if(isMainBoss)
        {
            mainBoss = FindObjectOfType<MainBoss>();
        }
        else
        {
            boss = FindObjectOfType<Boss>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMoovement.Dead){
            audioSource.Stop();
        }

        if(isMainBoss){
            if(mainBoss.bossHealth <= 0){
                audioSource.Stop();
            }
        }
        else{
            if(boss.bossHealth <= 0){
                audioSource.Stop();
            }
        }
    }
}
