using UnityEngine;

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
/// 캐릭터 이동 공통부분 전반 담당
/// Player와 Enemy에서 Character를 상속받아 사용
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
    private Vector3 direction;
    public float xMin, xMax, yMin, yMax;
    public float tilt;

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
    private void FixedUpdate()
    {
        rigidbody.velocity = direction * moveSpeed;
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            Mathf.Clamp(rigidbody.position.y, yMin, yMax),
            0.0f
        );
        rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.velocity.x * -tilt,0.0f );
    }
    public void DirectionToMove(Vector3 direction)
    {
        this.direction = direction;
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
