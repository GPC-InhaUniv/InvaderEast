using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1번

public class EnemyShotStraight :  IEnemyShotPattern
{

    float AttackWaitTime=1.0f;


    IEnumerator ShootStraight()
    {
        while(true)
        {
          //  gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);

            yield return new WaitForSeconds(AttackWaitTime);
        }
    }


    public void StartEnemyPattern()
    {
       // StartCoroutine(ShootStraight());
    }
}
