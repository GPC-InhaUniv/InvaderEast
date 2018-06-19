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

    const int EnemyQueueSize = 30;
    const int EnemyBulletQueueSize = 100;
    const int PlayerBulletQueueSize = 100;
    
    /// <summary>
    /// 각종 프리펍 로드
    /// 주석 된 부분 값만 바꿔주면 바로 쓸수 있음
    /// </summary>
    void Start ()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();

        //---큐 생성
        CreateQueue(EnemyQueue, EnemyQueueSize, EnemyPrefab);
        CreateQueue(EnemyBulletQueue, EnemyBulletQueueSize, EnemyBulletPrefab);
        CreateQueue(PlayerBulletQueue, PlayerBulletQueueSize, PlayerBulletPrefab);
        CreateQueue(PlayerSpreadBulletQueue, PlayerBulletQueueSize/10, PlayerSpreadBulletPrefab);
        CreateQueue(HomingMissileQueue, PlayerBulletQueueSize/10, HomingMissilePrefab);
        CreateQueue(StraightMissileQueue, PlayerBulletQueueSize/10, StraightMissilePrefab);
    }

    void CreateQueue(Queue<GameObject> queue, int size, GameObject prefab)
    {
        queue = new Queue<GameObject>();
        if(prefab != null)
        {
            for (int i = 0; i < size; i++)
            {
                GameObject gameObject = Instantiate(prefab);
                queue.Enqueue(gameObject);
                gameObject.SetActive(false);
                Debug.Log("Enqueue");
            }
        }
        else Debug.Log("Prefab이 존재하지 않음! : prefab is " + prefab.ToString());
    }

    public GameObject GetEnemyObject()
    {
        GameObject gameObject;
        gameObject = EnemyQueue.Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }

    public void PutEnemyObject(GameObject gameObject)
    {
        if (EnemyQueue.Count > 0)
        {
            EnemyQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        else Debug.Log("EnemyQueue : UnderFlow Error");
    }

    public GameObject GetEnemyBulletObject()
    {
        GameObject gameObject;
        gameObject = EnemyBulletQueue.Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }

    public void PutEnemyBulletObject(GameObject gameObject)
    {
        if (EnemyBulletQueue.Count > 0)
        {
            EnemyBulletQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        else Debug.Log("EnemyBulletQueue : UnderFlow Error");
    }

    public GameObject GetPlayerBulletObject()
    {
        GameObject gameObject;
        gameObject = PlayerBulletQueue.Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }

    public void PutPlayerBulletObject(GameObject gameObject)
    {
        if (PlayerBulletQueue.Count > 0)
        {
            PlayerBulletQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        else Debug.Log("PlayerBulletQueue : UnderFlow Error");
    }

    public GameObject GetPlayerSpreadBulletObject()
    {
        GameObject gameObject;
        gameObject = PlayerSpreadBulletQueue.Dequeue();
        gameObject.SetActive(true);
        return gameObject;
    }

    public void PutPlayerSpreadBulletObject(GameObject gameObject)
    {
        if (PlayerSpreadBulletQueue.Count > 0)
        {
            PlayerSpreadBulletQueue.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
        else Debug.Log("PlayerSpreadBulletQueue : UnderFlow Error");
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