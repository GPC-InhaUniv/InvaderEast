using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 이동 공통부분 전반 담당
/// Player와 Enemy에서 Character를 상속받아 사용
/// </summary>
public class Character : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public int life;

    public virtual void Move(Vector3 direction)
    {

    }
    public virtual void Attack()
    {

    }
    public virtual void OnTriggerEnter(Collider other)
    {

    }
}
