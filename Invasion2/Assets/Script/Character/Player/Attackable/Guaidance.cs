using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guaidance : MonoBehaviour, ISubAttackable
{
    [SerializeField]
    GameObject homingMissile;
    [SerializeField]
    Transform spawnPos;

    void Start()
    {
        homingMissile = Resources.Load("HomingMissile",typeof(GameObject)) as GameObject;
        spawnPos = GameObject.FindWithTag("FirePos").GetComponent<Transform>();
        
    }


    void Update()
    {

    }

    public void Attack(int power)
    {
        Debug.Log("호밍 미사일 : " + homingMissile);
        Debug.Log("스폰 좌표 : " + spawnPos);
        if (power == 40)
        {
            Instantiate(homingMissile, spawnPos.transform.position,spawnPos.transform.rotation);
        }
    }
}
