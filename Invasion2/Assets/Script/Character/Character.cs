﻿using System.Collections;
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
    protected int life;
    protected Vector3 target;

    protected new Rigidbody rigidbody;

    /*[SerializeField]
    protected Direction direction;*/
    public virtual void Move(Direction direction)
    {
        Debug.Log(direction);
        //this.direction = direction;
        
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
