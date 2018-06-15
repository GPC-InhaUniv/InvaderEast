using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotFiveTimes : MonoBehaviour, IEnemyShotPattern
{
    float AttackWaitTime;
    float coolDown;

    GameObject bulletPrefab;



	void Start ()
    {
        AttackWaitTime = 2.0f;
        coolDown = 2.0f;
        bulletPrefab = GameObject.FindGameObjectWithTag("EnemyBullet");
        StartEnemyPattern();
	}

    IEnumerator ShootFiveTimes()
    {
        GameObject gameObject;

        while(true)
        {
            for(int i = 0; i < 5; i++)
            {
                gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(AttackWaitTime);
            }

            yield return new WaitForSeconds(coolDown);
        }
    }

    public void StartEnemyPattern()
    {
        
    }
}
