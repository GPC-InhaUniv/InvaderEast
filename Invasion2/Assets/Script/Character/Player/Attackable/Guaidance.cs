using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 박상원 & 이재환
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
    new Rigidbody rigidbody;
    [SerializeField]
    GameObject homingMissile;
    [SerializeField]
    Transform spawnPos;
    [SerializeField]
    protected Transform target;
    float angle;
    [SerializeField]
    protected float rotateSpeed;
    [SerializeField]
    protected float moveSpeed;
    protected Vector3 chasing;
    int power;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        homingMissile = Resources.Load("HomingMissile",typeof(GameObject)) as GameObject;
        spawnPos = GameObject.FindWithTag("SubFirePos").GetComponent<Transform>();
        target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        HomingMove();
    }
    public void Attack(int power)
    {
        this.power = power;
        Debug.Log("호밍 미사일 : " + homingMissile);
        Debug.Log("스폰 좌표 : " + spawnPos);
        if (power == 40)
        {
            Instantiate(homingMissile, spawnPos.transform.position, Quaternion.identity);
        }
    }

    void HomingMove()
    {
        if(target)
        {
            chasing = target.transform.position - rigidbody.transform.position;
        }
        else
        {
            LostTarget();
        }
        Quaternion targetRotate = Quaternion.LookRotation(chasing);
        Quaternion SmoothRotate = Quaternion.Slerp(rigidbody.transform.rotation, targetRotate, rotateSpeed * Time.deltaTime);
        rigidbody.transform.rotation = SmoothRotate;
        rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }

    void LostTarget()
    {
        rigidbody.velocity = transform.forward * moveSpeed;
    }
}
