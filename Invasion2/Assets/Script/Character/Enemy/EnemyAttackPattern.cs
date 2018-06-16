using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 담당자 : 김지섭

// 적 캐릭터 총알 패턴입니다
// Instantiate 부분을 따로 start 메서드에서 합칠 예정입니다

public class EnemyAttackPattern : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    GameObject playerObject;

    float waitTime;
    float waitTime2;

    List<GameObject> bulletsList;


    void Start()
    {
        waitTime = 0.0f;

        playerObject = GameObject.Find("Player");

        bulletsList = new List<GameObject>();

        for (int i = 0; i < 50; i++)
        {
            
            bulletsList.Add(Instantiate(bulletPrefab, transform.position, transform.rotation));
            
        }



        StartCoroutine(ShootTwoinNumber());

    }


    class ShotStraights
    {

    }




    public IEnumerator ShootStraight()
    {
        waitTime = 1.0f;

        while (true)
        {


            yield return new WaitForSeconds(waitTime);
        }
    }

    public IEnumerator ShootFiveTimes()
    {
        waitTime = 0.5f;

        waitTime2 = 1.0f;

        GameObject TempObject;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                TempObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(waitTime);
            }

            yield return new WaitForSeconds(waitTime2);
        }

    }

    public IEnumerator ShootInductionBullet()
    {
        waitTime = 1.0f;

        GameObject TempObject;

        while (true)
        {
            TempObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            TempObject.transform.LookAt(playerObject.transform.position);

            yield return new WaitForSeconds(waitTime);


        }

    }

    public IEnumerator ShootTwoinNumber()
    {
        waitTime = 2.0f;

        GameObject TempObject;

        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                TempObject = Instantiate(bulletPrefab, transform.position + new Vector3((i % 2 == 0) ? -0.6f : 0.6f, 0, 0), transform.rotation);

            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    public IEnumerator ShootFanwise()
    {
        waitTime = 2.0f;
        Quaternion quaternion;
        float startAngle = 150.0f;
        float gapAngle = 15.0f;

        GameObject TempObject;

        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                quaternion = Quaternion.AngleAxis(startAngle + (gapAngle * i), Vector3.up);
                TempObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
                TempObject.transform.rotation = quaternion;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }


}













