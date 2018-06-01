using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 쉽게 불러올 수 있도록
/// 클래스 밖에 선언하였음.
/// </summary>

public class Player : Character
{
    IMainAttackable mainAttack;
    ISubAttackable subAttack;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(direction);
        Attack();
    }

    public override void Attack()
    {
        mainAttack.Attack(10);
        subAttack.Attack(10);
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
