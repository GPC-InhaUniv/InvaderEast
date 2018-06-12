using System.Collections;
using UnityEngine;

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
    [SerializeField]
    private GameObject enemyEjectPos;
    [SerializeField]
    private Transform player;
    [SerializeField]
    
    public float MoveLength;
    [Range(1, 2)]
    public float SaveZone;

    private bool firstCRrunning;
    private bool secondCRrunning;
    private bool thirdCRrunning;
    private bool fourthCRrunning;
    private bool fourthPatternFlag;
    float lifeRatio;
    private int shotCount;
    private int laserInterval;
    // Use this for initialization
    void Start()
    {
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
        lifeRatio = (currentLife / maxLife) * 100;
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
            Instantiate(bullet, mainShotPos.transform.position, mainShotPos.transform.rotation);
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
            Quaternion AngleOfFire = Quaternion.Euler(i * 15, -90, -90);
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
        Vector3 setPos = new Vector3(1f, 0, 0);
        Instantiate(enemy, enemyEjectPos.transform.position + setPos, enemyEjectPos.transform.rotation);
        Instantiate(enemy, enemyEjectPos.transform.position - setPos, enemyEjectPos.transform.rotation);
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
