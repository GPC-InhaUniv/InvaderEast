using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// </summary>

public class Player : Character
{
    IMainAttackable mainAttack;
    ISubAttackable subAttack;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    /*private void FixedUpdate()
    {
        Move(direction);
        Attack();
    }*/

    public override void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.STOP:
                rigidbody.velocity = Vector3.zero;
                break;
            case Direction.UP:
                target = new Vector3(0.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.DOWN:
                target = new Vector3(0.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.LEFT:
                target = new Vector3(-1.0f, 0.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.RIGHT:
                target = new Vector3(1.0f, 0.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            default:
                break;
        }
    }

    public override void Attack()
    {
        /*mainAttack.Attack(10);
        subAttack.Attack(10);*/
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
