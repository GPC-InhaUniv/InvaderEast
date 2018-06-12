using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEffect : MonoBehaviour
{

    public GameObject ShotEffected;

   

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.tag == "Enemy")
        {
            Instantiate(ShotEffected, transform.position, Quaternion.Euler(1.0f, 1.0f, 1.0f));
        }

        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
    void Start()
    {
       
    }

    void Update()

    {

    }
}
