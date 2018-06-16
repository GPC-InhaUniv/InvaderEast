using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAttackCtrl : MonoBehaviour, IMainAttackable
{
    [SerializeField]
    GameObject subSkill;
  
    


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
