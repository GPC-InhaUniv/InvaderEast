using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour, IMainAttackable
{
    public GameObject SpawnPosition;
    public GameObject BulletPrefab1;
   

    public void Start()
    {

    }

    public void Testbtn()
    {
        Attack(10);
    }

    public void Attack(int power)
    {
        if (power <= 10)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power <= 20)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
              SpawnPosition.transform.rotation);
        }
        else if (power <= 30)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power <= 40)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
    }
    
}
