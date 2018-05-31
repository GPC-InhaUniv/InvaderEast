using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 이동 공통부분 전반 담당
/// Player와 Enemy에서 Character를 상속받아 사용
/// </summary>
public enum Direction
{
    STOP,
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

    public new Rigidbody rigidbody;

    public Direction direction;
    public virtual void Move(Direction direction)
    {
        Vector3 target;
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
    public virtual void Attack()
    {

    }
    public virtual void OnTriggerEnter(Collider other)
    {

    }
}
