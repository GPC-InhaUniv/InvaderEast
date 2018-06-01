using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : MonoBehaviour, IMainAttackable, ISubAttackable
{
    public GameObject SpawnPosition;
    public GameObject BulletPrefab;
        
    public float Power = 10;

    public void Attack(int NumberofShot)
    {
        if (Power == 10)
        {
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
             SpawnPosition.transform.rotation);
        }
        else if (Power == 20 )
        {
            Instantiate(BulletPrefab, new Vector3(SpawnPosition.transform.position.x-1, SpawnPosition.transform.position.y, SpawnPosition.transform.position.z),
             SpawnPosition.transform.rotation);
            Instantiate(BulletPrefab, new Vector3(SpawnPosition.transform.position.x + 1, SpawnPosition.transform.position.y, SpawnPosition.transform.position.z),
             SpawnPosition.transform.rotation);
        }
        else if(Power == 30)
        {
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
    }

   

    void Start()
    {

    }

}
