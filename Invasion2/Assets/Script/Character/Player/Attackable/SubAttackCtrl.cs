using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubAttackCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject straightMissile;
    [SerializeField]
    GameObject homingMissile;
  
    GuaidanceMove homingMove;
   

    public PlayerType playerType;


    [SerializeField]
    const float CoolTime = 3.0f;


    private void Start()
    {
        homingMove = gameObject.GetComponentInChildren<GuaidanceMove>();
    //    homingMove.playerType = playerType;
    }


    void HomingMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        //Debug.Log("호밍 미사일 : " + homingMissile);
        //Debug.Log("스폰 좌표 : " + rightSpawnPos);
        //Debug.Log("스폰 좌표 : " + leftSpawnPos);
        
        homingMissile = PoolManager.Instance.GetPlayerBulletObject();
        homingMissile.transform.position = rightSpawnPos;
      //  homingMissile.transform.rotation = Quaternion.identity;

        homingMissile = PoolManager.Instance.GetPlayerBulletObject();
        homingMissile.transform.position = leftSpawnPos;
    //    homingMissile.transform.rotation = Quaternion.identity;

    }

    void StraightMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        //Debug.Log("스폰 좌표 : " + rightSpawnPos);
        //Debug.Log("스폰 좌표 : " + leftSpawnPos);

        straightMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Sin);
        straightMissile.transform.position = rightSpawnPos;
       // straightMissile.transform.rotation = Quaternion.identity;

        straightMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Sin);
        straightMissile.transform.position = leftSpawnPos;
      //  straightMissile.transform.rotation = Quaternion.identity;
    }

 
    public void Attack(int power)
    {

        switch (playerType)
        {
            case PlayerType.Sin:
                StraightMissile();
                break;
            case PlayerType.Ho:
                HomingMissile();
                break;
            default:
                break;
        }
    }
}
