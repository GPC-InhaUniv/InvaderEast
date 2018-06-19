using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 담당자 : 김지섭

// 적 캐릭터 총알 패턴입니다

public class EnemyAttackPattern
{

    public IEnumerator EnemyPattern1() // 하나씩 발사하는 패턴
    {
        float attackWaitTime = 1.0f;

        while (true)
        {
            Debug.Log("패턴 1, 발사");

            yield return new WaitForSeconds(attackWaitTime);
        }
    }

    public IEnumerator EnemyPattern2() // 5발 연속으로 발사하는 패턴
    {
        float attackWaitTime = 0.5f;

        float coolDown = 1.0f;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("패턴 2, 발사");

                yield return new WaitForSeconds(attackWaitTime);
            }

            yield return new WaitForSeconds(coolDown);
        }

    }

    public IEnumerator EnemyPattern3() // 캐릭터 위치로 발사하는 패턴
    {
        float attackWaitTime = 1.0f;

        while (true)
        {
            Debug.Log("패턴 3, 발사");

            yield return new WaitForSeconds(attackWaitTime);


        }

    }

    public IEnumerator EnemyPattern4() // 부채꼴로 퍼지게 발사하는 패턴
    {
        float attackWaitTime = 2.0f;

        Quaternion quaternion;

        float startAngle = 150.0f;
        float gapAngle = 15.0f;

        //GameObject tempObject;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                quaternion = Quaternion.AngleAxis(startAngle + (gapAngle * i), Vector3.up);

                Debug.Log("패턴 4, 발사");
                //tempObject.transform.rotation = quaternion;
            }

            yield return new WaitForSeconds(attackWaitTime);
        }
    }
}