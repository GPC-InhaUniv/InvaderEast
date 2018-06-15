using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttackTest :  IEnemyShotPattern
{
    
    public IEnumerator ShootStraight()
    {
        while(true)
        {
            Debug.Log("적 공격");
            yield return new WaitForSeconds(AttackWaitTime);
        }
        
    }

    public void StartEnemyPattern()
    {
    //    StartCoroutine(ShootStraight());
    }

    public float AttackWaitTime = 2;
    

      
            
}

    

