using UnityEngine;
using System.Collections;
// 담당자 : 박상원

/// <summary>
/// 적의 전투기 타입
/// </summary>
public enum EnemyType
{
    Gyo = 1,
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
    [SerializeField]
    protected EnemyType enemyType;
    protected int giveScore;
    protected int giveMaxGold;
    EnemyAttackPattern enemyPattern;

    private void OnEnable()
    {
        SetEnemyInfo();
        StartCoroutine(TimeDelay());
    }
    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1f);
        if (gameObject.activeSelf == true)
            ChangeType(enemyType);
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemyPattern = gameObject.GetComponent<EnemyAttackPattern>();
        // ChangeType(enemyType);
        maxLife = 5;
        StageManager.Instance.restart += new Restart(Died);
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        SetEnemyInfo();
    }

    private void SetEnemyInfo()
    {
        currentLife = maxLife;
        enemyType = (EnemyType)Random.Range(1, 5);
        giveMaxGold = Random.Range(1, 10);
        direction = (Direction)Random.Range(1, 6);
    }


    //타입 변경시마다 코루틴 종료
    private void ChangeType(EnemyType type)
    {

        switch (type)
        {
            case EnemyType.Gyo:
                giveScore = 100;

                StartCoroutine(enemyPattern.EnemyPattern1());
                break;
            case EnemyType.Tong:
                giveScore = 150;
                StartCoroutine(enemyPattern.EnemyPattern2());
                break;
            case EnemyType.Bub:
                giveScore = 200;
                StartCoroutine(enemyPattern.EnemyPattern3());
                break;
            case EnemyType.Gyu:
                giveScore = 250;
                StartCoroutine(enemyPattern.EnemyPattern4());
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
        StageManager.Instance.RemoveEnemy(gameObject);
        PoolManager.Instance.PutEnemyObject(gameObject);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        // StageManager.Instance.RemoveEnemy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Debug.Log("나감");
            Died();
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("PlayerBullet"))
        {
            currentLife--;
            if (currentLife <= 0)
            {
                gameMediator.SpawnItem(gameObject);
                Died();
            }
        }
        if (other.tag == ("HomingMissile"))
        {
            gameMediator.SpawnItem(gameObject);
            Died();
        }
    }
}
