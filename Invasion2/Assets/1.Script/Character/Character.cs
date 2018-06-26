using UnityEngine;

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
    LEFT =1,
    LEFTDOWN=2,
    DOWN=3,
    RIGHTDOWN=4,
    RIGHT=5,
    LEFTUP,
    RIGHTUP,
    UP,
}

/// <summary>
/// Player와 Enemy에서 Character를 상속받아 사용
/// 캐릭터 이동, 공격, 콜리더 접촉 여부 판정 등 공통적으로
/// 사용되는 함수들을 만들어두었다.
/// </summary>
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed;
    protected int power;
    protected int currentLife;
    [SerializeField]
    protected int maxLife;
    protected Vector3 target;
    protected new Rigidbody rigidbody;
    protected bool attacking = false;
    protected Vector3 playerDirection;
    [SerializeField]
    protected float xMin, xMax, zMin, zMax;
    [SerializeField]
    protected float tilt;

    public bool Attacking
    {
        get { return attacking; }
        set { attacking = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
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

    public void DirectionToMove(Vector3 direction)
    {
       playerDirection = direction;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                target = Vector3.forward;
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.DOWN:
                target = Vector3.back;
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFT:
                target = Vector3.left;
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHT:
                target = Vector3.right;
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFTUP:
                target = new Vector3(-1.0f, 0.0f, 1.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHTUP:
                target = new Vector3(1.0f, 0.0f, 1.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.LEFTDOWN:
                target = new Vector3(-1.0f, 0.0f, -1.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.RIGHTDOWN:
                target = new Vector3(1.0f, 0.0f, -1.0f);
                rigidbody.velocity = target * moveSpeed;
                break;
            case Direction.STOP:
                rigidbody.velocity = Vector3.zero;
                break;
            default:
                break;
        }
    }

    public abstract void Attack();

    public abstract void OnTriggerEnter(Collider other);
}
