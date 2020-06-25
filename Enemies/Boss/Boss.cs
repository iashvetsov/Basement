using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public bool isSpider;
    public float minRange = 1.5f, maxRange = 2.0f;
    public bool isBossFight;
    public int bossHealth = 100;
    bool bossIsDead;
    public bool isAttacked;

    //Animator
    Animator animator;

    //Boss health slider
    public Slider bossHealthSlider;

    //Falling Object
    public GameObject fallingObject;
    public Transform minCreateFallingObjectTransform;
    public Transform maxCreateFallingObjectTransform;
    private Transform CreateFallingObjectTransform;
    bool createFallingObject = true;
    float createFallingObjectsTimer;

    //Left/Right Object
    public GameObject LeftObject;
    public GameObject RightObject;
    public Transform leftCreateLRObjectTransform;
    public Transform rightCreateLRObjectTransform;
    bool createLRObject = true;
    float createLRObjectsTimer;
    public GameObject player;
    bool isLeftObject;

    public StartBossFight startBossFight;
    
    public SpriteRenderer sprite;

    void Start()
    {
        //Get Animator
        animator = gameObject.GetComponent<Animator>();
        CreateFallingObjectTransform = minCreateFallingObjectTransform;
    }

    void Update()
    {
        animator.SetBool("isAttacked", isAttacked);
        if (isAttacked)
        {
            if(sprite != null)
                sprite.color = new Color(207, 37, 37, 255);
        }
        else
        {
            if(sprite != null)
                sprite.color = new Color(255, 255, 255, 255);
        }
        bossHealthSlider.value = bossHealth;
        if(bossHealth <= 0)
        {
            bossHealth = 0;
            bossIsDead = true;
        }
        if (bossIsDead)
        {
            animator.SetBool("bossIsDead", true);
            StartCoroutine(BossIsDead());
        }
        if (isAttacked)
        {
            StartCoroutine(IsAttackedToTrue());
        }
         
        if (startBossFight.bossFightisStarted)
        {
            //Create falling object
            float randSec = Random.Range(minRange, maxRange);
            createFallingObjectsTimer -= Time.fixedDeltaTime;
            float x = Random.Range(minCreateFallingObjectTransform.position.x, maxCreateFallingObjectTransform.position.x);
            if(Time.timeScale != 0 || !bossIsDead){
            if (createFallingObject && createFallingObjectsTimer <= 0)
            {
                createFallingObject = false;
                CreateFallingObjects(randSec, new Vector3(x, CreateFallingObjectTransform.position.y, CreateFallingObjectTransform.position.z));
            }

            //Create LR Object
            float randLRsec = Random.Range(4f, 8f);
            createLRObjectsTimer -= Time.deltaTime;
            
            if (createLRObject && createLRObjectsTimer <= 0)
            {
                createLRObject = false;
                if (isLeftObject && !isSpider)
                {
                    CreateLFObject(randLRsec, new Vector3(leftCreateLRObjectTransform.position.x,
                        player.transform.position.y,
                        leftCreateLRObjectTransform.position.z), LeftObject);
                    isLeftObject = !isLeftObject;
                }
                else if (!isLeftObject && !isSpider)
                {
                    CreateLFObject(randLRsec, new Vector3(rightCreateLRObjectTransform.position.x,
                        player.transform.position.y,
                        rightCreateLRObjectTransform.position.z), RightObject);
                    isLeftObject = !isLeftObject;
                }

                if (isLeftObject && isSpider)
                {
                    CreateLFObject(randLRsec, new Vector3(leftCreateLRObjectTransform.position.x,
                        rightCreateLRObjectTransform.position.y,
                        leftCreateLRObjectTransform.position.z), LeftObject);
                    isLeftObject = !isLeftObject;
                }
                else if (!isLeftObject && isSpider)
                {
                    CreateLFObject(randLRsec, new Vector3(rightCreateLRObjectTransform.position.x,
                        rightCreateLRObjectTransform.position.y,
                        rightCreateLRObjectTransform.position.z), RightObject);
                    isLeftObject = !isLeftObject;
                }
            }
            }
        }
    }

    IEnumerator BossIsDead()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    IEnumerator IsAttackedToTrue()
    {
        yield return new WaitForSeconds(0.3f);
        isAttacked = false;
    }

    void CreateFallingObjects(float _randSec, Vector3 _randPosition)
    {
        Instantiate(fallingObject, _randPosition, Quaternion.identity);
        createFallingObjectsTimer = _randSec;
        createFallingObject = true;
    }

    void CreateLFObject(float _randSec, Vector3 _position, GameObject _creatingObject)
    {
        Instantiate(_creatingObject, _position, Quaternion.identity);
            
        createLRObjectsTimer = _randSec;
        createLRObject = true;
    }
}
