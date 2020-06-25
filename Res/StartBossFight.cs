using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{

    public bool bossFightisStarted = false;

    public GameObject door;
    public GameObject mainCam;
    public GameObject bossCam;
    public GameObject bossHealthSlider;
    public Boss boss;
    public GameObject exitDoor;
    public GameObject musicObject;

    public PlayerMoovement player;

    private void Start()
    {
        bossCam.SetActive(false);
        mainCam.SetActive(true);
        bossHealthSlider.SetActive(false);
        exitDoor.SetActive(false);
        musicObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            bossFightisStarted = true;
            musicObject.SetActive(true);
        }
        bossHealthSlider.SetActive(true);
    }

    private void Update()
    {
        if (bossFightisStarted && boss.bossHealth >= 0 && !player.Dead)
        {
            door.GetComponent<Door>().isOpen = false;
            bossCam.SetActive(true);
            mainCam.SetActive(false);
        }

        if (boss.bossHealth <= 0)
        {
            bossHealthSlider.SetActive(false);
            bossCam.SetActive(false);
            mainCam.SetActive(true);
            exitDoor.SetActive(true);
        }

        if (player.Dead)
        {
            bossHealthSlider.SetActive(false);
        }

    }
}
