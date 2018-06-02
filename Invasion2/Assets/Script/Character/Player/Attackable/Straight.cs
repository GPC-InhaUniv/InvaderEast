using UnityEngine;

public class Straight : MonoBehaviour, IMainAttackable, ISubAttackable
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

            Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
            SpawnPosition.transform.rotation);
        }
        else if (power == 20)
        {
            Instantiate(BulletPrefab, SpawnPosition.transform.position,
            SpawnPosition.transform.rotation);

            Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
            SpawnPosition.transform.rotation);

            Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
            SpawnPosition.transform.rotation);

            Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
            SpawnPosition.transform.rotation);

            Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
            SpawnPosition.transform.rotation);

            Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
            SpawnPosition.transform.rotation);
        }
        else if (power == 30)
        {
           Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position + SpaPosition,
           SpawnPosition.transform.rotation);

           Instantiate(BulletPrefab, SpawnPosition.transform.position - SpaPosition,
           SpawnPosition.transform.rotation);

        }
    }



    void Start()
    {
        SpaPosition = new Vector3(1.25f, 0, 0);
    }

}
