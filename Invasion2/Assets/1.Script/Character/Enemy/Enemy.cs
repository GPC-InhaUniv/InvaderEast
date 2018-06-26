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
/// Character를 상속받았고 Character 스크립트에 있는
/// Move 메서드의 매개변수에 enum Direction에 추가한
/// UP,DOWN,LEFT,DOWN 등의 방향을 전달해주면
/// 이동할 수 있도록 하였고 8방향 이동이 가능하다.
/// -----------------------------------------
/// Enemy 타입은 총 4가지이며 ChangeType 함수에
/// enum EnemyType에 들어있는 EnemyType 중 하나가
/// 전달되면 switch을 이용하여 EnemyType에 맞는
/// EnemyPattern을 실행하는 코루틴을 시작한다.
/// -----------------------------------------
/// </summary>
public class Enemy : Character
{
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
        maxLife = 5;
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(Died);
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
        GameMediator.Instance.PutEnemyObjectAtPool(gameObject);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
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
                GameMediator.Instance.PlaySound(SoundType.EnemyDead);
                GameMediator.Instance.ChangeScore(giveScore);
                GameMediator.Instance.SpawnItem(gameObject);
                Died();
            }
        }
        if (other.tag == ("HomingMissile"))
        {
            GameMediator.Instance.PlaySound(SoundType.EnemyDead);
            GameMediator.Instance.ChangeScore(giveScore);
            GameMediator.Instance.SpawnItem(gameObject);
            Died();
        }
        if(other.tag == ("StraightMissile"))
        {
            GameMediator.Instance.PlaySound(SoundType.EnemyDead);
            GameMediator.Instance.ChangeScore(giveScore);
            GameMediator.Instance.SpawnItem(gameObject);
            Died();
        }
    }
    public override void Attack() { }

    private void OnDestroy()
    {
        GameMediator.Instance.DoGameOver -= new GameMediator.DoGameOverDelegate(Died);
    }
}
