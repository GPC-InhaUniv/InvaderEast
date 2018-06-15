using UnityEngine;

public class Sector : MonoBehaviour, IMainAttackable
{
    /// <summary>
    /// 작성자 : 이재환
    /// 파워마다 공격 프리팹 변경
    /// </summary>
    public GameObject SpawnPosition;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject BulletPrefab3;
    public GameObject BulletPrefab4;
    
    void Start()
    {

    }

    public void Testbtn()
    {
        Attack(40);
    }

    public void Attack(int power)
    {
        if (power <= 10)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power <= 20)
        {
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
