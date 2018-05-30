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
    new Rigidbody rigidbody;
    public Vector3 pos;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(pos);
    }

    public override void Move(Vector3 position)
    {
        //rigidbody.position = position;
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }
}
