using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 캐릭터가 이동할 방향
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

/// <summary>
/// 캐릭터 이동 공통부분 전반 담당
/// Player와 Enemy에서 Character를 상속받아 사용
/// </summary>
public class Character : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed;
    protected int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    protected int maxLife;
    protected Vector3 target;

    protected new Rigidbody rigidbody;

    GameMediator gameMediator;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }

    public void Move(Vector3 direction)
    {
        Debug.Log(direction);
        //this.direction = direction;

        rigidbody.velocity = direction * moveSpeed;
        Attack();
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {

            case Direction.UP:
                target = new Vector3(0.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.DOWN:
                target = new Vector3(0.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFT:
                target = new Vector3(-1.0f, 0.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHT:
                target = new Vector3(1.0f, 0.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFTUP:
                target = new Vector3(-1.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHTUP:
                target = new Vector3(1.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFTDOWN:
                target = new Vector3(-1.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHTDOWN:
                target = new Vector3(1.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.STOP:
                rigidbody.velocity = Vector3.zero;
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
