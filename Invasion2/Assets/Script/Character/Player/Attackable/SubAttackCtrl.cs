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

    [SerializeField]
    const float CoolTime = 3.0f;


    void Start()
    {

    }

    void CheckedPlayerType(PlayerType playerType)
    {
        if (playerType == PlayerType.Deung)
        {
            barrier.SetActive(true);
        }
        if (playerType == PlayerType.Ho)
        {
            guaidanceMissile.SetActive(true);
        }
        if (playerType == PlayerType.Sin)
        {
            strightMissile.SetActive(true);
        }
    }
   
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
