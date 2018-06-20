using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// 플레이어의 메인공격 함수
/// </summary>
public class MainAttackCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float xInterval = 0.22f;
    [SerializeField]
    float yInterval = -0.5f;    

    const float sectorDegree = 3f;

    //test field
    [SerializeField]
    int magazineCount;
    [SerializeField]
    int maxmagazineCount;
    [SerializeField]
    int power;
    [SerializeField]
    GameObject SpreadPrefab;
    [SerializeField]
    PlayerType playerType;


    private void Start()
    {
        //test code
        //maxmagazineCount = (int)(2 + Math.Truncate(power / 10f));
        //magazineCount = maxmagazineCount;
    }

    void DeungShipAttack()
    {
        GameObject bullet;
        bullet = Instantiate(SpreadPrefab, transform.position, Quaternion.identity);
        
    }

    void SinShipFirstAttack()
    {
        GameObject gameObject;
        gameObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void SinShipSecondAttack(float xPosition, float yPosition)
    {
        Vector3 positionR = new Vector3(xPosition, yPosition);
        Vector3 positionL = new Vector3(-xPosition, yPosition);
        Instantiate(bulletPrefab, positionL, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
        Instantiate(bulletPrefab, positionR, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
    }

    void SinShipThirdAttack()
    {
        SinShipFirstAttack();
        SinShipSecondAttack(xInterval, yInterval);
    }

    void SinShipFourthAttack()
    {
        SinShipThirdAttack();
        SinShipSecondAttack(xInterval * 2, yInterval * 2);
    }
    
    int HoShootCount(int power)
    {
        return (int)(2 * (1 + Math.Truncate(power / 10f)) + 1);
    }

    void HoShipAttack(int power)
    {
        int count = HoShootCount(power);
        float angle = (float)Math.Truncate(count / 2f) * sectorDegree;

        for (int i = 0; i < count; i++) 
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + angle, transform.rotation.z + 90f));
            // 반시계 반향으로  발사각을 돌려주는 코드
            angle -= sectorDegree; 
        }
    }
    
    public void Attack(int power)
    {
        switch (playerType)
        {
            case PlayerType.Sin:
                if (power < 10f)
                {
                    SinShipFirstAttack();
                }
                else if (power < 20f)
                {
                    SinShipSecondAttack(xInterval, 0f);
                }
                else if (power < 30f)
                {
                    SinShipThirdAttack();
                }
                else if (power == 30f)
                {
                    SinShipFourthAttack();
                }
                break;

            case PlayerType.Ho:
                HoShipAttack(power);
                break;

            case PlayerType.Deung:
                DeungShipAttack();
                break;

            default:
                break;
        }
    }
}
