using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniSpider : MonoBehaviour
{
    //Mooving
    Rigidbody2D rigidbody;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; 
    public float speed = -1;
    private bool m_FacingRight; 
    bool isDead;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
        rigidbody = GetComponent<Rigidbody2D>();
        if(transform.position.x > 45){
            speed = -4;
        }
        else if(transform.position.x < 45){
            speed = 4;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(speed, rigidbody.velocity.y);
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    void Update(){
        if(speed > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if(speed < 0 && m_FacingRight)
        {
            Flip();
        }

        if(isDead){
            animator.SetBool("isDead", true);
        }
    }

    //Flip
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //Collisions
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "DeadTrigger"){
            isDead = true;
        }
        if(collision.tag == "Player"){
            isDead = true;
        }
        if(collision.tag == "Weapon"){
            isDead = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "MiniSpider"){
            isDead = true;
        }
    }
    //Destroy
    public void MiniSpiderDead(){
        Destroy(gameObject);
    }
}
