using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubAttackCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject strightMissile;
    [SerializeField]
    GameObject guaidanceMissile;
    [SerializeField]
    GameObject barrier;

   

    public void Attack(int power, PlayerType playerType)
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
