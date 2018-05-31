using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 이동 공통부분 전반 담당
/// Player와 Enemy에서 Character를 상속받아 사용
/// </summary>
public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    LEFTUP,
    RIGHTUP,
    LEFTDOWN,
    RIGHTDOWN,
}
public class Character : MonoBehaviour
{
    public float moveSpeed;
    public int damage;
    public int life;
    public Vector3 pos;

    new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        pos = rigidbody.position;
    }

    public Direction direction;
    public virtual void Move(Direction direction)
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
            default:
                break;
        }
    }
    public virtual void Attack()
    {

    }
    public virtual void OnTriggerEnter(Collider other)
    {

    }
}
