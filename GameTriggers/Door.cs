using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;
    public bool isOpen;
    public bool haveKey;

    public int doorNumber;

    public enum DoorType
    {
        Door,
        Door_key,
        Door_arm
    }

    
    public DoorType doorType = DoorType.Door;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {   
        if (isOpen)
        {
            animator.SetBool("open", true);
        }
        else
        {
            animator.SetBool("open", false);
        }

        if(doorType == DoorType.Door_arm)
        {
            int doorNumberPath = PlayerPrefs.GetInt("DoorNumber");
            if(doorNumberPath >= doorNumber)
            {
                animator.SetBool("open", true);
            }
            else
            {
                animator.SetBool("open", false);
            }
        }
    }
}
