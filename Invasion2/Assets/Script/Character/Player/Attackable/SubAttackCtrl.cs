using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubAttackCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject straightMissile;
    [SerializeField]
    GameObject guaidanceMissile;
    [SerializeField]
    GameObject barrier;
    [SerializeField]
    PlayerType playerType;
    [SerializeField]
    const float CoolTime = 3.0f;

    void Start()
    {

    }

    void GuaidanceMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        //Debug.Log("호밍 미사일 : " + homingMissile);
        //Debug.Log("스폰 좌표 : " + rightSpawnPos);
        //Debug.Log("스폰 좌표 : " + leftSpawnPos);
        Instantiate(guaidanceMissile, rightSpawnPos, Quaternion.identity);
        Instantiate(guaidanceMissile, leftSpawnPos, Quaternion.identity);
    }

    void StraightMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        //Debug.Log("호밍 미사일 : " + homingMissile);
        //Debug.Log("스폰 좌표 : " + rightSpawnPos);
        //Debug.Log("스폰 좌표 : " + leftSpawnPos);
        Instantiate(straightMissile, rightSpawnPos, Quaternion.identity);
        Instantiate(straightMissile, leftSpawnPos, Quaternion.identity);
    }

    void Barrier()
    {
        Instantiate(barrier, transform.position, transform.rotation);
    }

    public void Attack(int power)
    {
        
        switch(playerType)
        {
            case PlayerType.Sin:
                StraightMissile();
                break;
            case PlayerType.Ho:
                GuaidanceMissile();
                break;
            case PlayerType.Deung:
                Barrier();
                break;
            default:
                break;
        }
    }
}
