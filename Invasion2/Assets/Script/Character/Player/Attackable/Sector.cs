using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour,IMainAttackable
{
    public void Attack(int NumberofShot)
    {
        switch (NumberofShot)
        {
            case 1:
                NumberofShot++;
                break;
            case 2:
                break;
            default:
                break;
        }
    }

   
    void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}
}
