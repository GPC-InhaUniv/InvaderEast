using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour, ISubAttackable
{
    public GameObject barrier;

    [SerializeField]
    const float CoolTime = 3.0f;

    void Start()
    {
           
    }

    public void Attack(int power)
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyBullet")
        {
            barrier.SetActive(false);
        }
        StartCoroutine(ShieldRecharge());
    }
    
    IEnumerator ShieldRecharge()
    {
        yield return new WaitForSeconds(CoolTime);
        barrier.SetActive(true);
    }
}