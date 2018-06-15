using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackCtrl : MonoBehaviour, ISubAttackable
{
    [SerializeField]
    GameObject subSkill;
    
    [SerializeField]
    PlayerType playerType;

   
    

    

    public void Attack(int power)
    {
        switch (playerType)
        {
            case PlayerType.Sin:

                break;
            case PlayerType.Ho:
                break;

            case PlayerType.Deung:
                break;

            default:
                break;
        }
    }
}
