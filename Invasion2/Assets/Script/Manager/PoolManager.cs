using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 관리하는 Pool 리스트 : 
/// EnemyQueue(적 객체), 
/// EnemyBulletQueue(적의 총알 객체), 
/// PlayerBulletQueue(플레이어의 타입 및 파워에 따른 총알 객체)
/// //집에 가고 십다.............
/// </summary>
public class PoolManager : Singleton<PoolManager>
{
    protected PoolManager() { }
    GameMediator gameMediator;

    Queue<GameObject> EnemyQueue;
    Queue<GameObject> EnemyBulletQueue;
    Queue<GameObject>[] PlayerBulletQueue;

    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    GameObject EnemyBulletPrefab;
    [SerializeField]
    GameObject[] PlayerBulletPrefab;

    const int EnemyQueueSize = 30;
    const int EnemyBulletQueueSize = 100;
    const int PlayerBulletQueueSize = 20;
    
    void Start ()
    {
        //EnemyPrefab = Resources.Load("EnemyPrefab") as GameObject; //아직 없다고 한다...ㅠ
        //EnemyBulletPrefab = Resources.Load("EnemyBulletPrefab") as GameObject; //얘도 아직 없다고 한다...............

        PlayerBulletPrefab = new GameObject[8];
        PlayerBulletPrefab[0] = Resources.Load("Straight1") as GameObject;
        PlayerBulletPrefab[1] = Resources.Load("Straight2") as GameObject;
        PlayerBulletPrefab[2] = Resources.Load("Straight3") as GameObject;
        PlayerBulletPrefab[3] = Resources.Load("Straight4") as GameObject;

        PlayerBulletPrefab[4] = Resources.Load("Sector1") as GameObject;
        PlayerBulletPrefab[5] = Resources.Load("Sector2") as GameObject;
        PlayerBulletPrefab[6] = Resources.Load("Sector3") as GameObject;
        PlayerBulletPrefab[7] = Resources.Load("Sector4") as GameObject;

        CreateQueue(EnemyQueue, EnemyQueueSize, EnemyPrefab);
        CreateQueue(EnemyBulletQueue, EnemyBulletQueueSize, EnemyBulletPrefab);
        PlayerBulletQueue = new Queue<GameObject>[8];
        for (int i = 0; i < PlayerBulletQueue.Length-1; i++)
        {
            if(PlayerBulletPrefab[i] != null)
            {
                CreateQueue(PlayerBulletQueue[i], PlayerBulletQueueSize, PlayerBulletPrefab[i]);
            }
        }
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
        else Debug.Log("Prefab가 존재하지 않음! : " + prefab.ToString());
    }

    public GameObject GetEnemy()
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

    /// <summary>
    /// index값 정리해준다. 
    /// 0~3 = Sinship의 파워에 따른 공격, 
    /// 4~7 = Hoship의 파워에 따른 공격, 
    /// 8~12 = Deungship의 파워에 따른 공격(얘는 바뀔수 있음)
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GameObject GetPlayerBulletObject(int index)
    {
        if(index < 0)
        {
            Debug.Log("index는 음수가 아닙니다.");
            return null;
        }
        else if(index > PlayerBulletQueue.Length)
        {
            Debug.Log("index가 Queue의 크기보다 큽니다.");
            return null;
        }
        else
        {
            GameObject gameObject;
            gameObject = PlayerBulletQueue[index].Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }
    }

    /// <summary>
    /// index값 정리해준다. 
    /// 0~3 = Sinship의 파워에 따른 공격, 
    /// 4~7 = Hoship의 파워에 따른 공격, 
    /// 8~12 = Deungship의 파워에 따른 공격(얘는 바뀔수 있음)
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="index"></param>
    public void PutPlayerBulletObject(GameObject gameObject, int index)
    {
        if (index < 0)
        {
            Debug.Log("index는 음수가 아닙니다.");
        }
        else if (index > PlayerBulletQueue.Length)
        {
            Debug.Log("index가 Queue의 크기보다 큽니다.");
        }
        else
        {
            if (PlayerBulletQueue[index].Count > 0)
            {
                PlayerBulletQueue[index].Enqueue(gameObject);
                gameObject.SetActive(false);
            }
            else Debug.Log("PlayerBulletQueue[" + index + "] : UnderFlow Error");
        }
    }
}