using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : MonoBehaviour, ISubAttackable
{
    public GameObject shild;
    
    
    public void Attack(int power)
    {

    }
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        shild.SetActive(false);
    }
    //IEnumerable ()
    //{

    //}
   
}
