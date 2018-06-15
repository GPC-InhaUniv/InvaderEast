﻿using UnityEngine;

// 담당자 : 박상원

/// <summary>
/// 플레이어 타입 선택
/// </summary>
public enum PlayerType
{
    Deung,
    Sin,
    Ho,
}

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
/// Player와 Enemy에서 Character를 상속받아 사용
/// 캐릭터 이동, 공격, 콜리더 접촉 여부 판정 등 공통적으로
/// 사용되는 함수들을 만들어두었다.
/// </summary>
public class Character : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected int damage;
    protected int currentLife;
    protected int maxLife;
    protected Vector3 target;
    protected new Rigidbody rigidbody;
    protected GameMediator gameMediator;
    protected bool attacking = false;
    protected Vector3 playerDirection;
    [SerializeField]
    protected float xMin, xMax, yMin, yMax;
    [SerializeField]
    protected float tilt;

    public bool Attacking
    {
        get { return attacking; }
        set { attacking = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int CurrentLife
    {
        get { return currentLife; }
        set { currentLife = value; }
    }
    public int MaxLife
    {
        get { return maxLife; }
        set { maxLife = value; }
    }
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
 
    public void DirectionToMove(Vector3 direction)
    {
        this.playerDirection = direction;
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
