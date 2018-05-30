using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public Enemy CreateEnemy(Enemy EnemyPrefab)
    {
        return Instantiate(EnemyPrefab);
    }
}
