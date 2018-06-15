using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotInductionBullet : MonoBehaviour, IEnemyShotPattern
{
    float AttackWaitTime;
    GameObject playerObject;

    GameObject bulletPrefab;



    void Start ()
    {
        AttackWaitTime = 2.0f;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        bulletPrefab = GameObject.FindGameObjectWithTag("EnemyBullet");
        StartEnemyPattern();
    }

	IEnumerator ShootinductionBullet()
    {
        GameObject gameObject;

        while(true)
        {
            gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            gameObject.transform.LookAt(playerObject.transform.position);

            yield return new WaitForSeconds(AttackWaitTime);
        }
	}

    public void StartEnemyPattern()
    {
        StartCoroutine(ShootinductionBullet());
    }
}
