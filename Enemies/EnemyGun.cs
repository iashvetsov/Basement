using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public Transform gun;
    public GameObject bullet;

    public float rateOfFire = 1.0f;

    bool isFire = true;
    // Update is called once per frame
    void Update()
    {
        if (isFire)
        {
            isFire = false;
            StartCoroutine(CreateBullet());
        }
    }

    IEnumerator CreateBullet()
    {
        
        Instantiate(bullet, gun);
        yield return new WaitForSeconds(rateOfFire);
        isFire = true;
    }
}
