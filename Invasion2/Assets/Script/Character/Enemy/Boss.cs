using System.Collections;
using UnityEngine;

/// <summary>
/// 담당자 : 김정수
/// 
/// Pool 완성시 총알 생성 부 변경해야 함.
/// 패턴1: 플레이어를 향해 총알 발사
/// 패턴2: 흩뿌리는 총알 발사
/// 패턴3: 적 생성
/// 패턴4: Savezone을 남겨두고 레이져 발사
/// 패턴4는 방향이 반대인 패턴이 하나 더있어야한다.
/// </summary>

public class Boss : Enemy
{
    
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject mainShotPos;
    [SerializeField]
    private GameObject laserShotPos;
    [SerializeField]
    private GameObject subShotPos;
   
    private Transform player;
    [SerializeField]
    
    private float MoveLength;
    [SerializeField]
    [Range(1, 3)]
    private float SaveZone;

    private bool firstCRrunning;
    private bool secondCRrunning;
    private bool thirdCRrunning;
    private bool fourthCRrunning;
    private bool fourthPatternFlag;
    [SerializeField]
    float lifeRatio;
    private int shotCount;
    private int laserInterval;
    // Use this for initialization
    void Start()
    {
       
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        maxLife = 1000;
        currentLife = maxLife;
        giveScore = 1000;
        giveMaxGold = 100;
        StartCoroutine(BossPattern());
       
        shotCount = 0;
        laserInterval = 0;
        laserShotPos.SetActive(false);

    }

    IEnumerator BossPattern()
    {
        lifeRatio = ((float)currentLife / (float)maxLife) * 100;
        if (!firstCRrunning && !fourthCRrunning)
            StartCoroutine(FirstPattern());
        if (lifeRatio < 80 && !secondCRrunning && !fourthCRrunning)
            StartCoroutine(SecondPattern());
        if (lifeRatio < 60 && !thirdCRrunning && !fourthCRrunning)
        {
            StartCoroutine(ThirdPattern());
        }

        if (lifeRatio < 30 && !fourthCRrunning)
        {
            if (laserInterval > 5)
            {
                if (fourthPatternFlag)
                    StartCoroutine(FourthPattern());
                else
                    StartCoroutine(ReverseFourthPattern());
            }
        }
        yield return (0);
        StartCoroutine(BossPattern());
    }

    IEnumerator FirstPattern()
    {
        firstCRrunning = true;
        if (shotCount < 5)
        {
            mainShotPos.transform.LookAt(player);
            GameObject bullet = PoolManager.Instance.GetEnemyBulletObject();
            bullet.transform.position = mainShotPos.transform.position;
            bullet.transform.rotation = mainShotPos.transform.rotation;
            yield return new WaitForSeconds(0.2f);
            shotCount++;
            StartCoroutine(FirstPattern());
        }
        else
        {
            shotCount = 0;
            laserInterval++;
            yield return new WaitForSeconds(2.0f);
            firstCRrunning = false;

        }

    }
    IEnumerator SecondPattern()
    {
        if (!firstCRrunning)
            StartCoroutine(FirstPattern());
        secondCRrunning = true;
        for (int i = 0; i < 12; i++)
        {
            if (i % 4 == 0)
                continue;
            Quaternion AngleOfFire = Quaternion.Euler(0, (-i * 15)-90, 0);
            Instantiate(bullet, subShotPos.transform.position, subShotPos.transform.rotation = AngleOfFire);

            yield return new WaitForSeconds(0.1f);

        }

        yield return new WaitForSeconds(2.0f);
        laserInterval++;
        secondCRrunning = false;
       
    }

    IEnumerator ThirdPattern()
    {
        thirdCRrunning = true;
        StageManager.Instance.Spawn(enemy, EnemyType.Gyo);
        StageManager.Instance.Spawn(enemy, EnemyType.Gyo);
        StageManager.Instance.Spawn(enemy, EnemyType.Gyo);
        yield return new WaitForSeconds(2.0f);
        thirdCRrunning = false;
    }

    IEnumerator FourthPattern()
    {
        fourthCRrunning = true;
        fourthPatternFlag = !fourthPatternFlag;
        direction = Direction.LEFT;
        yield return new WaitForSeconds(MoveLength / moveSpeed);
        direction = Direction.STOP;
        laserShotPos.SetActive(true);
        yield return new WaitForSeconds(1.0f / moveSpeed);
        direction = Direction.RIGHT;
        yield return new WaitForSeconds((MoveLength * 2 - SaveZone) / moveSpeed);
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.0f / moveSpeed);
        direction = Direction.LEFT;
        yield return new WaitForSeconds((MoveLength - SaveZone) / moveSpeed);
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.0f / moveSpeed);
        laserShotPos.SetActive(false);
        laserInterval = 0;
        fourthCRrunning = false;

    }

    IEnumerator ReverseFourthPattern()
    {
        fourthCRrunning = true;
        fourthPatternFlag = !fourthPatternFlag;
        direction = Direction.RIGHT;
        yield return new WaitForSeconds(MoveLength / moveSpeed);
        direction = Direction.STOP;
        laserShotPos.SetActive(true);
        yield return new WaitForSeconds(1.0f / moveSpeed);
        direction = Direction.LEFT;
        yield return new WaitForSeconds((MoveLength * 2 - SaveZone) / moveSpeed);
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.0f / moveSpeed);
        direction = Direction.RIGHT;
        yield return new WaitForSeconds((MoveLength - SaveZone) / moveSpeed);
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.0f / moveSpeed);
        laserShotPos.SetActive(false);
        laserInterval = 0;
        fourthCRrunning = false;

    }

}
