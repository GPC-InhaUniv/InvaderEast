using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// ---------------------------------------
/// 목표물을 추적하는 유도 미사일
/// 현재는 타겟을 미리 지정해두고
/// 추적하는 것만 가능하며 화면에 보이는
/// Enemy 중 가장 가까운 Enemy를 추적하도록
/// 구현할 예정에 있다.
/// ---------------------------------------
/// 테스트 중 정상작동을 확인하기 위해
/// SerializeField 를 사용하여 인스펙터에
/// 몇몇 필드가 보이도록 하였다.
/// ---------------------------------------
/// </summary>
public class Guaidance : MonoBehaviour, ISubAttackable
{
    GameObject homingMissile;
    [SerializeField]
    GameObject[] enemys;
    [SerializeField]
    GameObject enemy;
    Transform player;
    Vector3 rightSpawnPos;
    Vector3 leftSpawnPos;
    [SerializeField]
    GameObject target;
    Vector3 chasing;

    new Rigidbody rigidbody;

    float angle;
    float enemyDistance;
    float distance;
    float minDistance;
    float rotateSpeed = 45.0f;
    float moveSpeed = 10.0f;
    int power;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        homingMissile = Resources.Load("HomingMissile",typeof(GameObject)) as GameObject;
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        FindTaget();
        //target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        HomingMove();
    }
    public void Attack(int power)
    {
        this.power = power;
        rightSpawnPos = player.transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        leftSpawnPos = player.transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        Debug.Log("호밍 미사일 : " + homingMissile);
        Debug.Log("스폰 좌표 : " + rightSpawnPos);
        Debug.Log("스폰 좌표 : " + leftSpawnPos);
        if (power == 40)
        {
            Instantiate(homingMissile, rightSpawnPos, Quaternion.identity);
            Instantiate(homingMissile, leftSpawnPos, Quaternion.identity);
        }
    }

    void HomingMove()
    {
        if (target)
        {
            chasing = target.transform.position - rigidbody.transform.position;
        }
        else
        {
            LostTarget();
        }
        Quaternion chaingTarget = Quaternion.LookRotation(chasing);
        Quaternion SmoothRotate = Quaternion.Slerp(rigidbody.transform.rotation, chaingTarget, rotateSpeed * Time.deltaTime);
        rigidbody.transform.rotation = SmoothRotate;
        rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }

    void LostTarget()
    {
        rigidbody.velocity = transform.forward * moveSpeed;
    }

    GameObject FindTaget()
    {
        distance = Vector3.Distance(player.transform.position, enemys[0].transform.position);
        //Debug.Log("거리 : " + distance);
        foreach(GameObject enemyObject in enemys)
        {
            enemyDistance = Vector3.Distance(player.transform.position, enemyObject.transform.position);
            //Debug.Log("거리 : " + enemyDistance);
            //Debug.Log("너는 누구냐 : " + enemyObject);
            if(enemyDistance<distance)
            {
                target = enemyObject;
                distance = enemyDistance;
            }
        }
        return target;
    }
}
