using System.Collections;
using System.Collections.Generic;
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
    private Transform target;

    Vector3 addPostion;

    private int shotCount;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        life = 1000;
        giveScore = 1000;
        giveMaxGold = 100;
        StartCoroutine(FirstPattern());
        shotCount = 0;
        laserShotPos.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator FirstPattern()
    {
        if (shotCount < 5)
        {
            mainShotPos.transform.LookAt(target);
            Instantiate(bullet, mainShotPos.transform.position, mainShotPos.transform.rotation);
            yield return new WaitForSeconds(0.2f);
            shotCount++;
            StartCoroutine(FirstPattern());
        }
        else
        {
            shotCount = 0;
            StartCoroutine(SecondPattern());
            yield return new WaitForSeconds(2.0f);
            
        }

        
    }
    IEnumerator SecondPattern()
    {


        for (int i = 0; i < 12; i++)
        {
            if (i % 4 == 0)
                continue;
            Quaternion test = Quaternion.Euler(i*15, -90, -90);
            Instantiate(bullet, subShotPos.transform.position, subShotPos.transform.rotation = test);

            yield return new WaitForSeconds(0.1f);

        }
        StartCoroutine(ThirdPattern());


    }

    IEnumerator ThirdPattern()
    {
        Vector3 setPos = new Vector3(1f, 0, 0);
        Instantiate(enemy, enemyEjectPos.transform.position + setPos, enemyEjectPos.transform.rotation);
        Instantiate(enemy, enemyEjectPos.transform.position - setPos, enemyEjectPos.transform.rotation);
        yield return new WaitForSeconds(0);
        StopAllCoroutines();
        StartCoroutine(FourthPattern());

    }

    IEnumerator FourthPattern()
    {
       
        
        
        direction = Direction.LEFT;
        yield return new WaitForSeconds(1.5f); 
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.5f);
        laserShotPos.SetActive(true);
        direction = Direction.RIGHT;
        yield return new WaitForSeconds(3f);
        direction = Direction.STOP;
        yield return new WaitForSeconds(1.5f);
        direction = Direction.LEFT;
        yield return new WaitForSeconds(1.5f);
        direction = Direction.STOP;
        yield return new WaitForSeconds(0.5f);
        laserShotPos.SetActive(false);
        StartCoroutine(FirstPattern());
    }

}
