using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 100;
    public bool isAttacked;
    public bool haveKey;

    public GameObject click_button;
    public GameObject key;
    public GameObject need_key;
    public GameObject completeLevelMenu;
    GameObject pathGameObject;
    PlayerMoovement playerMoovement;

    Door pathDoor;

    private void Start()
    {
        completeLevelMenu.SetActive(false);
        playerMoovement = GetComponent<PlayerMoovement>();
    }

    public int GetHealth()
    {
        return health;
    }

    private void Update()
    {
        if (haveKey)
        {
            key.SetActive(true);
        }
        else
        {
            key.SetActive(false);
        }

        if(health >= 100)
        {
            health = 100;
        }
        else if(health <= 0)
        {
            health = 0;
        }

        if (isAttacked)
        {
            StartCoroutine(Attacked());
        }
    }

    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacked = false;
    }

    public bool GetIsAttacked()
    {
        return isAttacked;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "OpenObject")
        {
            pathGameObject = collision.gameObject;
            click_button.SetActive(true);
        }
        if (collision.tag == "ArmBody")
        {
            pathDoor = collision.GetComponentInParent<Door>();
            click_button.SetActive(true);
        }
        if(collision.tag == "ExitDoor")
        {
            pathGameObject = collision.gameObject;
            //collision.GetComponent<AudioSource>().PlayOneShot(playerMoovement.a_lvlComplete);
            click_button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "OpenObject")
        {
            pathGameObject = null;
            click_button.SetActive(false);
        }
        if (collision.tag == "ArmBody")
        {
            pathDoor = null;
            click_button.SetActive(false);
        }
        if (collision.tag == "ExitDoor")
        {
            pathGameObject = null;
            click_button.SetActive(false);
        }
    }

    public void ClickButtonPress()
    {
        if(pathGameObject != null)
        {
            if (pathGameObject.GetComponent<Door>() != null)
            {
                if (pathGameObject.GetComponent<Door>().doorType == Door.DoorType.Door)
                {
                    pathGameObject.GetComponent<Door>().isOpen = !pathGameObject.GetComponent<Door>().isOpen;
                }

                if (pathGameObject.GetComponent<Door>().doorType == Door.DoorType.Door_key && haveKey)
                {
                    pathGameObject.GetComponent<Door>().isOpen = !pathGameObject.GetComponent<Door>().isOpen;
                    haveKey = false;
                }

                if (pathGameObject.GetComponent<Door>().doorType == Door.DoorType.Door_key)
                {
                    if (!haveKey)
                    {
                        if (pathGameObject.GetComponent<Door>().isOpen == false)
                        {
                            need_key.SetActive(true);
                        }
                    }
                }
            }else if (pathGameObject.GetComponent<ExitDoor>().isExitDoor)
            {
                if(pathGameObject.GetComponent<ExitDoor>().nextLevelNumber <= 8)
                {
                    //SOUND COMPLETE LEVEL!
                    pathGameObject.GetComponent<AudioSource>().PlayOneShot(playerMoovement.a_lvlComplete);
                    PlayerPrefs.SetInt("levelNumber", pathGameObject.GetComponent<ExitDoor>().nextLevelNumber);
                    completeLevelMenu.SetActive(true);
                    //Time.timeScale = 0;
                    //SceneManager.LoadScene("Levels");
                }
                if(pathGameObject.GetComponent<ExitDoor>().nextLevelNumber > 8)
                {
                    SceneManager.LoadScene("FinalBoss");
                }
            }
        }
        if (pathDoor != null)
        {
            if (pathDoor.doorType == Door.DoorType.Door_arm)
            {
                PlayerPrefs.SetInt("DoorNumber", pathDoor.doorNumber);
            }
        }
    }
}
