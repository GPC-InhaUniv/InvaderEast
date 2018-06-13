using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour, IMainAttackable
{
    /// <summary>
    /// 파워마다 총알 탄창수 제한 미완성
    /// 재장전 코루틴 미완성
    /// </summary>
    public GameObject SpawnPosition;
    public GameObject BulletPrefab1;

    //private readonly int maxBulliet = 5;
    //private bool isReload = false;
    //private int currBullet = 2;
    //private WaitForSeconds wsReload;

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
            //isReload = (--currBullet % maxBulliet == 0);
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
