using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 에너미 생성하는 팩토리
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    public Enemy CreateEnemy(Enemy EnemyPrefab)
    {
        Debug.Log("call CreateEnemy");
        return Instantiate(EnemyPrefab);
    }
}
