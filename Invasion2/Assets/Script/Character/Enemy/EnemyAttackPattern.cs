using System.Collections;
using UnityEngine;

// 담당자 : 김지섭

// 적 캐릭터 총알 패턴입니다

public class EnemyAttackPattern : MonoBehaviour
{
    GameObject bullet;
<<<<<<< HEAD
    Transform shotPos;

    // 하나씩 발사하는 패턴
    public IEnumerator EnemyPattern1(Transform transform) 
=======

    [SerializeField]
    GameObject shotPos;

    public IEnumerator EnemyPattern1() // 하나씩 발사하는 패턴
>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
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

<<<<<<< HEAD
    // 5발 연속으로 발사하는 패턴
    public IEnumerator EnemyPattern2(Transform transform)
=======
    public IEnumerator EnemyPattern2() // 5발 연속으로 발사하는 패턴
>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
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

<<<<<<< HEAD
    // 캐릭터 위치로 발사하는 패턴
    public IEnumerator EnemyPattern3(Transform transform)
    { 
        shotPos = transform;
=======
    public IEnumerator EnemyPattern3() // 캐릭터 위치로 발사하는 패턴
    {
        

>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
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

<<<<<<< HEAD
    // 부채꼴로 퍼지게 발사하는 패턴
    public IEnumerator EnemyPattern4(Transform transform)
=======
    public IEnumerator EnemyPattern4() // 부채꼴로 퍼지게 발사하는 패턴
>>>>>>> 1f2640dcf9e6661a75f2d79c196c1c73ce4f3f9c
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