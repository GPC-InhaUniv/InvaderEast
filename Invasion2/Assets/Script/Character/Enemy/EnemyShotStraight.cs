using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotStraight : MonoBehaviour, IEnemyShotPattern
{

    float AttackWaitTime;

    GameObject bulletPrefab;



    void start()
    {
        AttackWaitTime = 1.0f;
        bulletPrefab = GameObject.FindGameObjectWithTag("EnemyBullet");
        StartEnemyPattern();
    }

    IEnumerator ShootStraight()
    {

        GameObject gameObject;

        while(true)
        {
            gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);

            yield return new WaitForSeconds(AttackWaitTime);
        }
    }


    public void StartEnemyPattern()
    {
        StartCoroutine(ShootStraight());
    }
}
