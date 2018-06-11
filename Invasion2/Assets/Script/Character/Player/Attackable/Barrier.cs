using UnityEngine;

public class Barrier : MonoBehaviour, ISubAttackable
{
    public GameObject barrier;


    void Start()
    {
        
    }

    public void Attack(int power)
    {
        
    }
   
    private void OnTriggerEnter(Collider collider)
    {
        barrier.SetActive(false);
    }
    
}