using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 사용하기 편하도록
/// 클래스 밖으로 빼놓았음.
/// </summary>
public enum EnemyType
{

}

public enum Direction
{
    UP,
    DOWN,
    RIGHT,
    LEFT,
}

public class Enemy : Character
{
    public int giveScore;
    public int giveMaxGold;

    public override void Move(Vector3 direction)
    {
        base.Move(direction);
    }

    public override void Attack()
    {
        
    }

    public void Pattern()
    {

    }
}
