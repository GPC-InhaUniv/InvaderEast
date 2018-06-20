using System.Collections;
using UnityEngine;

// 담당자 : 김지섭

// 적 캐릭터 총알 패턴입니다

public class EnemyAttackPattern : MonoBehaviour
{
    GameObject bullet;

    [SerializeField]
    GameObject shotPos;

    public IEnumerator EnemyPattern1() // 하나씩 발사하는 패턴

    {
      
        float attackWaitTime = 1.0f;
        
        while (true)
        {
            bullet = PoolManager.Instance.GetEnemyBulletObject();
            bullet.transform.position = shotPos.transform.position;
            bullet.transform.rotation = shotPos.transform.rotation;
            yield return new WaitForSeconds(attackWaitTime);
        }
    }


    // 5발 연속으로 발사하는 패턴

    public IEnumerator EnemyPattern2() 

    {
      

        float attackWaitTime = 0.5f;

        float coolDown = 1.0f;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                bullet = PoolManager.Instance.GetEnemyBulletObject();
                bullet.transform.position = shotPos.transform.position;
                bullet.transform.rotation = shotPos.transform.rotation;
                yield return new WaitForSeconds(attackWaitTime);
            }

            yield return new WaitForSeconds(coolDown);
        }

    }


    // 캐릭터 위치로 발사하는 패턴

    public IEnumerator EnemyPattern3()
    {
        
        float attackWaitTime = 1.0f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        while (true)
        {
            shotPos.transform.LookAt(player.transform);
            bullet = PoolManager.Instance.GetEnemyBulletObject();
            bullet.transform.position = shotPos.transform.position;
            bullet.transform.rotation = shotPos.transform.rotation;
            yield return new WaitForSeconds(attackWaitTime);


        }

    }


    // 부채꼴로 퍼지게 발사하는 패턴

    public IEnumerator EnemyPattern4()
    {
        float attackWaitTime = 2.0f;

        Quaternion quaternion;

        float startAngle = 150.0f;
        float gapAngle = 15.0f;


        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                quaternion = Quaternion.AngleAxis(startAngle + (gapAngle * i), Vector3.up); 
                bullet = PoolManager.Instance.GetEnemyBulletObject();
                bullet.transform.position = shotPos.transform.position;
                bullet.transform.rotation = quaternion;
            }

            yield return new WaitForSeconds(attackWaitTime);
        }
    }
}