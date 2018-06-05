using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour, IMainAttackable
{
    public GameObject SpawnPosition;
    public GameObject BulletPrefab1;
    public GameObject ShotEffect;

    public void Testbtn()
    {
        Attack(10);
    }

    public void Attack(int power)
    {
        if (power == 10)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power == 20)
        {

        }
        else if (power == 30)
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
