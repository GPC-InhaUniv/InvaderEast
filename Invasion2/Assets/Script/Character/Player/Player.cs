using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 쉽게 불러올 수 있도록
/// 클래스 밖에 선언하였음.
/// </summary>
public enum MainAttack
{
    Sector,
    Wedge,
    Straight,
}

public enum SubAttack
{
    Straight,
    Guaidance,
    Shild,
}

public class Player : Character
{
    public override void Move(Vector3 direction)
    {
        base.Move(direction);
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }
}
