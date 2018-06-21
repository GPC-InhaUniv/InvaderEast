using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 최대원
/// 관리하는 Pool 리스트 : 
/// EnemyQueue(적 객체), 
/// EnemyBulletQueue(적의 총알 객체), 
/// PlayerBulletQueue(플레이어의 타입 및 파워에 따른 총알 객체를 담은 큐의 배열)
/// PlayerSpreadBulletPrefab(등 쉽의 탄환)
/// HomingMissileQueue(유도 미사일)
/// 
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
    protected PoolManager() { }
    GameMediator gameMediator;

    Queue<GameObject> EnemyQueue;
    Queue<GameObject> EnemyBulletQueue;
    Queue<GameObject> PlayerBulletQueue;
    Queue<GameObject> PlayerSpreadBulletQueue;
    Queue<GameObject> HomingMissileQueue;
    Queue<GameObject> StraightMissileQueue;
    Queue<GameObject> SpreadBulletQueue;

    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    GameObject EnemyBulletPrefab;
    [SerializeField]
    GameObject PlayerBulletPrefab;
    [SerializeField]
    GameObject PlayerSpreadBulletPrefab;
    [SerializeField]
    GameObject HomingMissilePrefab;
    [SerializeField]
    GameObject StraightMissilePrefab;
    [SerializeField]
    GameObject SpreadBulletPrefab;

    const int EnemyQueueSize = 30;
    const int EnemyBulletQueueSize = 100;
    const int PlayerBulletQueueSize = 100;

    void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        EnemyPrefab = Resources.Load("Enemy") as GameObject;
        EnemyBulletPrefab = Resources.Load("EnemyBullet") as GameObject;
       // HomingMissilePrefab = Resources.Load("HomingMissile") as GameObject;
      //  StraightMissilePrefab = Resources.Load("StraightMissile") as GameObject;
       // SpreadBulletPrefab = Resources.Load("SpreadBullet") as GameObject;
        SetQueue();
    }

    public void SetQueue()
    {
        EnemyQueue = CreateQueue(EnemyQueue, EnemyQueueSize, EnemyPrefab);
        EnemyBulletQueue = CreateQueue(EnemyBulletQueue, EnemyBulletQueueSize, EnemyBulletPrefab);
      //  PlayerBulletQueue = CreateQueue(PlayerBulletQueue, PlayerBulletQueueSize, PlayerBulletPrefab);
      //  PlayerSpreadBulletQueue = CreateQueue(PlayerSpreadBulletQueue, PlayerBulletQueueSize / 10, PlayerSpreadBulletPrefab);
      //  HomingMissileQueue = CreateQueue(HomingMissileQueue, PlayerBulletQueueSize / 10, HomingMissilePrefab);
      //  StraightMissileQueue = CreateQueue(StraightMissileQueue, PlayerBulletQueueSize / 10, StraightMissilePrefab);
    }

    Queue<GameObject> CreateQueue(Queue<GameObject> queue, int size, GameObject prefab)
    {
        queue = new Queue<GameObject>();
        if (prefab != null)
        {
            for (int i = 0; i < size; i++)
            {
                GameObject gameObject = Instantiate(prefab);
                queue.Enqueue(gameObject);
                gameObject.SetActive(false);
            }
        }
        else Debug.Log("Prefab이 존재하지 않음! : prefab is " + prefab.ToString());

        return queue;
    }

    public GameObject GetEnemyObject()
    {
        if (EnemyQueue.Count > 0)
        {
            GameObject gameObject;
            gameObject = EnemyQueue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }
        else
        {
            Debug.Log("EnemyQueue is Underflow exception");
            return null;
        }    
    }

    public void PutEnemyObject(GameObject gameObject)
    {
        EnemyQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetEnemyBulletObject()
    {
        if (EnemyBulletQueue.Count > 0)
        {
            GameObject gameObject;
            gameObject = EnemyBulletQueue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }

        else Debug.Log("EnemyBulletQueue : UnderFlow Error");
        return null;
    }

    public void PutEnemyBulletObject(GameObject gameObject)
    {
        EnemyBulletQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetPlayerBulletObject()
    {
        if (PlayerBulletQueue.Count > 0)
        {
            GameObject gameObject;
            gameObject = PlayerBulletQueue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }
        else Debug.Log("PlayerBulletQueue : UnderFlow Error");
        return null;
    }

    public void PutPlayerBulletObject(GameObject gameObject)
    {
        PlayerBulletQueue.Enqueue(gameObject);
        gameObject.SetActive(false);

    }

    public GameObject GetPlayerSpreadBulletObject()
    {
        if (PlayerSpreadBulletQueue.Count > 0)
        {
            GameObject gameObject;
            gameObject = PlayerSpreadBulletQueue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }
        else Debug.Log("PlayerSpreadBulletQueue : UnderFlow Error");
        return null;
    }

    public void PutPlayerSpreadBulletObject(GameObject gameObject)
    {
        PlayerSpreadBulletQueue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetPlayerMissileObject(PlayerType type)
    {
        GameObject bullet;
        switch (type)
        {
            case PlayerType.Deung:
                bullet = null;
                Debug.Log("Return null!");
                break;

            case PlayerType.Sin:
                bullet = HomingMissileQueue.Dequeue();
                bullet.SetActive(true);
                break;

            case PlayerType.Ho:
                bullet = StraightMissileQueue.Dequeue();
                bullet.SetActive(true);
                break;

            default:
                bullet = null;
                Debug.Log("Return null!");
                break;
        }
        return bullet;

    }

    public void PutPlayerMissileObject(GameObject gameObject, PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Deung:
                break;
            case PlayerType.Sin:
                if (HomingMissileQueue.Count > 0)
                {
                    HomingMissileQueue.Enqueue(gameObject);
                    gameObject.SetActive(false);
                }
                break;
            case PlayerType.Ho:
                if (StraightMissileQueue.Count > 0)
                {
                    StraightMissileQueue.Enqueue(gameObject);
                    gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

}