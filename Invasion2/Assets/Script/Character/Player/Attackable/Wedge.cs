﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wedge : MonoBehaviour, IMainAttackable
{
    public GameObject SpawnPosition;
    public GameObject BulletPrefab;
    
    Vector3 SpaPosition;

    public void Attack(int power)
    {
        if (power == 10)
        {
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power == 20)
        {

        }
        else if (power == 30)
        {

        }
    }

    void Start()
    {
        SpaPosition = new Vector3(1.25f, 0, 0);
    }

    
    void Update()
    {

    }
}
