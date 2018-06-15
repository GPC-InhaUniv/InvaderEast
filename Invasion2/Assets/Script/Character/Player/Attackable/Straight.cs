using UnityEngine;

public class Straight : MonoBehaviour, IMainAttackable, ISubAttackable
{
    /// <summary>
    /// 작성자 : 박상원 , 이재환
    /// 파워마다 공격 프리팹 변경
    /// </summary>
     
    
        //접근 제한자 수정.
    public Transform SpawnPosition;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject BulletPrefab3;
    public GameObject BulletPrefab4;


    //전략 패턴 X 수정 필요
    void Start()
    { 
        SpawnPosition = GameObject.FindWithTag("MainFirePos").GetComponent<Transform>();
        BulletPrefab1 = Resources.Load("Straight1", typeof(GameObject)) as GameObject;
        BulletPrefab2 = Resources.Load("Straight2", typeof(GameObject)) as GameObject;
        BulletPrefab3 = Resources.Load("Straight3", typeof(GameObject)) as GameObject;
        BulletPrefab4 = Resources.Load("Straight4", typeof(GameObject)) as GameObject;
    }

    public void Testbtn()
    {
        Attack(10);
    } 

    //power -> 공격 Type으로 변경
    //프리팹 -> List
    public void Attack(int power)
    {
        if (power <= 10)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power <= 20)
        {
            Debug.Log(power);
            Instantiate(BulletPrefab2, SpawnPosition.transform.position,
             SpawnPosition.transform.rotation);
        }
        else if (power <= 30)
        {
            Instantiate(BulletPrefab3, SpawnPosition.transform.position,
             SpawnPosition.transform.rotation);
        }
        else if (power <= 40)
        {
            Instantiate(BulletPrefab4, SpawnPosition.transform.position,
             SpawnPosition.transform.rotation);
        }
    }
}
