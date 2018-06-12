using UnityEngine;

/// <summary>
/// 적의 전투기 타입
/// </summary>
public enum EnemyType
{
    Gyo,
    Tong,
    Bub,
    Gyu
}

/// <summary>
/// Character를 상속받는다.
/// Move 메서드로 8방향 이동 가능
/// </summary>
public class Enemy : Character
{
    [SerializeField]
    protected Direction direction;
    public Direction EnemyDirection
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    protected EnemyType enemyType;
    public EnemyType TypeEnemy
    {
        get
        {
            return enemyType;
        }
    }

    protected int giveScore;
    public int GiveScore
    {
        get
        {
            return giveScore;
        }
    }

    protected int giveMaxGold;
    public int GiveMaxGold
    {
        get
        {
            return giveMaxGold;
        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        StageManager.Instance.callBackEnemyDead += new CallBackEnemyDead(Died);
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    public void Died()
    {

        gameMediator.SpawnItem(ItemType.PowerItem, this.transform);
        if (transform.position.y < -7f)
        {
           StageManager.Instance.callBackEnemyDead -= new CallBackEnemyDead(Died);
           StageManager.Instance.RemoveEnemy(this);
        }
    }
  
    public override void Attack()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public void Pattern()
    {

    }
}
