using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotFanwise : MonoBehaviour, IEnemyShotPattern
{
    float AttackWaitTime;

    GameObject bulletPrefab;



	// Use this for initialization
	void Start ()
    {
        AttackWaitTime = 2.0f;
        bulletPrefab = GameObject.FindGameObjectWithTag("EnemyBullet");
        StartEnemyPattern();
	}

    IEnumerator ShootFanwise()
    {
        Quaternion quaternion;
        float startAngle = 150.0f;
        float gapAngle = 15.0f;

        GameObject gameObject;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
                quaternion = Quaternion.AngleAxis(startAngle + (gapAngle * i), Vector3.up);

                gameObject.transform.rotation = quaternion;

            }

            yield return new WaitForSeconds(AttackWaitTime);

        }
    }

    public void StartEnemyPattern()
    {
        StartCoroutine(ShootFanwise());
    }
}
