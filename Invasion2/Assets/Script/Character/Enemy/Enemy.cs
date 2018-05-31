using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 사용하기 편하도록
/// 클래스 밖으로 빼놓았음.
/// Move는 재정의하여 Enemy에 맞도록
/// 내용을 채워넣었음.
/// </summary>
public enum EnemyType
{

}

public class Enemy : Character
{
    public int giveScore;
    public int giveMaxGold;

    new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pos = rigidbody.position;
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    public override void Move(Direction direction)
    {
        Vector3 target;
        Vector3 targetDirection;
        switch (direction)
        {
            case Direction.UP:
                target = new Vector3(0.0f, 10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.DOWN:
                pos = rigidbody.position;
                target = new Vector3(0.0f, -10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.LEFT:
                pos = rigidbody.position;
                target = new Vector3(-10.0f, 0.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.RIGHT:
                pos = rigidbody.position;
                target = new Vector3(10.0f, 0.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.LEFTUP:
                pos = rigidbody.position;
                target = new Vector3(-10.0f, 10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.RIGHTUP:
                pos = rigidbody.position;
                target = new Vector3(10.0f, 10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.LEFTDOWN:
                pos = rigidbody.position;
                target = new Vector3(-10.0f, -10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            case Direction.RIGHTDOWN:
                pos = rigidbody.position;
                target = new Vector3(10.0f, -10.0f, 0.0f);
                targetDirection = (target - pos).normalized;
                rigidbody.velocity = targetDirection * moveSpeed;
                Attack();
                break;
            default:
                break;
        }
    }

    public override void Attack()
    {
        
    }

    public void Pattern()
    {

    }
}
