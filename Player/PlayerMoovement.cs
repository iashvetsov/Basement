using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour
{
    //Audio Clips
    public AudioClip a_jump;
    public AudioClip a_attack;
    public AudioClip a_dead;
    public AudioClip a_attacked;
    public AudioClip a_lvlComplete;

    Animator animator;
    CharacterController2D controller;
    Player playerHealth;
    public Collider2D weaponCollider2D;
    public AudioSource audioSource;

    float moveX;
    bool isJump;
    bool playJumpSound;

    public bool Dead;
    public bool isAttack;
    public GameObject player;
    bool isAttakcedSuondPlay;
    public float run_speed = 40.0f;

    public bool isPC = true;

	void Start()
    {
		controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {   
        if(moveX != 0.0f)
        {
			animator.SetBool("isRunning", true);
        }
        else
        {
			animator.SetBool("isRunning", false);
		}
        //In PC control
        if (isPC)
        {
            moveX = Input.GetAxis("Horizontal") * run_speed;
            
            if (Input.GetButtonDown("Jump"))
            {
                if (!isJump)
                {
                    animator.SetTrigger("TakeOff");
                    animator.SetBool("isJumping", true);
                }
				isJump = true;
            }
        }

        //DEAD
        if(playerHealth.GetHealth() <= 0)
        {
            Dead = true;
        }

        if (Dead)
        {
            animator.SetBool("isDead", true);
            controller.enabled = false;
            enabled = false;
            audioSource.PlayOneShot(a_dead);
            //Destroy(player, 1.0f);
        }

        if(playerHealth.isAttacked)
        {
            if(!isAttakcedSuondPlay)
            {
                audioSource.PlayOneShot(a_attacked);
                isAttakcedSuondPlay = true;
            }
        }
        if(!playerHealth.isAttacked)
        {
            isAttakcedSuondPlay = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(moveX * Time.fixedDeltaTime, false, isJump);
        isJump = false;
    }

    public void RightButtonDown()
    {
        moveX = 1.0f * run_speed;
    }

    public void LeftButtonDown()
    {
        moveX = -1.0f * run_speed;
    }

    public void StopMooving()
    {
        moveX = 0.0f;
    }

    public void JumpButtonDown()
    {
        if (!isJump)
        {
            if (playJumpSound)
            {
                audioSource.PlayOneShot(a_jump);
            }
            animator.SetTrigger("TakeOff");
            animator.SetBool("isJumping", true);
        }
		isJump = true;
        playJumpSound = false;
    }

    public void AttackButtonDown()
    {
        if (!isAttack)
        {
            audioSource.PlayOneShot(a_attack);
            animator.SetTrigger("Attack");
            isAttack = true;
            StartCoroutine(AttackTimer());
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        playJumpSound = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //animator.SetBool("isJumping", false);
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }
}
