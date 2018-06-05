using UnityEngine;

public class Sector : MonoBehaviour, IMainAttackable
{
    public GameObject SpawnPosition;
    public GameObject BulletPrefab1;
    public GameObject BulletPrefab2;
    public GameObject BulletPrefab3;

    Vector3 SpaPosition;

    public void Attack(int power)
    {
        if (power == 10)
        {
            Instantiate(BulletPrefab1, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power == 20)
        {
            Instantiate(BulletPrefab2, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
        else if (power == 30)
        {
            Instantiate(BulletPrefab3, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);
        }
    }
}
