using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject laser;
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
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        life = 1000;
        giveScore = 1000;
        giveMaxGold = 100;
        StartCoroutine(FirstPattern());
        shotCount = 0;
        

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    IEnumerator FirstPattern()
    {
        if (shotCount < 5)
        {
            mainShotPos.transform.LookAt(target);
            Instantiate(bullet, mainShotPos.transform.position, mainShotPos.transform.rotation);
            yield return new WaitForSeconds(0.2f);
            shotCount++;
        }
        else
        {
            StartCoroutine(SecondPattern());
            yield return new WaitForSeconds(2.0f);
            shotCount = 0;
        }
       
        StartCoroutine(FirstPattern());
    }
    IEnumerator SecondPattern()
    {
        
        
        for (int i = 0; i<12;i++)
        {
           Quaternion test = Quaternion.Euler(15 * i, -90, -90);
            Instantiate(bullet, subShotPos.transform.position, subShotPos.transform.rotation = test );
            
            yield return new WaitForSeconds(0.1f);
            
        }
        yield return new WaitForSeconds(0);
        
    }

    
}
