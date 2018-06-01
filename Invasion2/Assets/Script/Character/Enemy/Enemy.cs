using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{

}

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 사용하기 편하도록
/// 클래스 밖으로 빼놓았음.
/// Move는 재정의하여 Enemy에 맞도록
/// 내용을 채워넣었음.
/// </summary>
/// 
public class Enemy : Character
{
    [SerializeField]
    protected Direction direction;

    protected int giveScore;
    protected int giveMaxGold;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    public override void Move(Direction direction)
    {
        Vector3 target;
        switch (direction)
        {

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
            case Direction.LEFTUP:
                target = new Vector3(-1.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.RIGHTUP:
                target = new Vector3(1.0f, 1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.LEFTDOWN:
                target = new Vector3(-1.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.RIGHTDOWN:
                target = new Vector3(1.0f, -1.0f, 0.0f);
                rigidbody.velocity = target * moveSpeed;
                Attack();
                break;
            case Direction.STOP:
                rigidbody.velocity = Vector3.zero;
                break;
            default:
                break;
        }
    }

    void Died()
    {
        StageManager.Instance.RemoveEnemy(this);
    }

    public override void Attack()
    {

    }

    public void Pattern()
    {

    }
}
