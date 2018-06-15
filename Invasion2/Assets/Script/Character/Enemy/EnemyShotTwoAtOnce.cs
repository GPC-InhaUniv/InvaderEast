using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotTwoAtOnce : MonoBehaviour, IEnemyShotPattern
{
    float AttackWaitTime;
    
    GameObject bulletPrefab;



    void start()
    {
        AttackWaitTime = 2.0f;
        bulletPrefab = GameObject.FindGameObjectWithTag("EnemyBullet");

    }

    public IEnumerator ShootTwoAtOnce()
    { 

        GameObject gameObject;

        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                gameObject = Instantiate(bulletPrefab, transform.position + new Vector3((i % 2 == 0) ? -0.6f : 0.6f, 0, 0), transform.rotation);

            }

            yield return new WaitForSeconds(AttackWaitTime);
        }
    }


    public void StartEnemyPattern()
    {
        StartCoroutine(ShootTwoAtOnce());
    }

}
