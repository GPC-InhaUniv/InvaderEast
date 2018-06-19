using UnityEngine;
// 담당자 : 박상원

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
/// -----------------------------------------
/// 각각의 Enemy 패턴들이 아직 Enemy 스크립트의 
/// Pattern() 메서드와 결합되지 않음
/// -----------------------------------------
/// Character를 상속받아 Character 스크립트에 있는
/// Move 메서드의 매개변수에 이동 방향을 전달해주면
/// 이동할 수 있도록 하였고 8방향 이동이 가능하다.
/// -----------------------------------------
/// </summary>
public class Enemy : Character
{
    [SerializeField]
    protected Direction direction;
    [SerializeField]
    private GameObject shotPos;

    
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
     
        ChangeType(enemyType);
    }

    
    private EnemyAttackPattern enemyPattern;
    //타입 변경시마다 코루틴 종료
    private void ChangeType(EnemyType type)
    {
    
        switch (type)
        {
            case EnemyType.Gyo:
                enemyPattern = new EnemyAttackPattern();
                StartCoroutine(enemyPattern.EnemyPattern1(shotPos.transform));
                break;
            case EnemyType.Tong:
                enemyPattern = new EnemyAttackPattern();
                StartCoroutine(enemyPattern.EnemyPattern2(shotPos.transform));
                break;
            case EnemyType.Bub:
                enemyPattern = new EnemyAttackPattern();
                StartCoroutine(enemyPattern.EnemyPattern3(shotPos.transform));
                break;
            case EnemyType.Gyu:
                enemyPattern = new EnemyAttackPattern();
                StartCoroutine(enemyPattern.EnemyPattern4(shotPos.transform));
                break;
            default:
                break;
        }
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
           StageManager.Instance.RemoveEnemy(this.gameObject);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public void Pattern()
    {
       
    }
}
