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

    private void Start()
    {
        //test code
        maxmagazineCount = (int)(2 + Math.Truncate(power / 10f));
        magazineCount = maxmagazineCount;
    }

    void deungShipAttack(int power)
    {
        GameObject bullet;
        bullet = Instantiate(SpreadPrefab, transform.position, Quaternion.identity);
        
    }

    void sinShipFirstAttack()
    {
        GameObject gameObject;
        gameObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    void sinShipSecondAttack(float xPosition, float yPosition)
    {
        Vector3 positionR = new Vector3(xPosition, yPosition);
        Vector3 positionL = new Vector3(-xPosition, yPosition);
        Instantiate(bulletPrefab, positionL, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
        Instantiate(bulletPrefab, positionR, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
    }

    void sinShipThirdAttack()
    {
        sinShipFirstAttack();
        sinShipSecondAttack(xInterval, yInterval);
    }

    void sinShipFourthAttack()
    {
        sinShipThirdAttack();
        sinShipSecondAttack(xInterval * 2, yInterval * 2);
    }

    int hoShootCount(int power)
    {
        return (int)(2 * (1 + Math.Truncate(power / 10f)) + 1);
    }

    void hoShipAttack(int power)
    {
        int count = hoShootCount(power);
        float angle = (float)Math.Truncate(count / 2f) * sectorDegree;

        for (int i = 0; i < count; i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y + angle, transform.rotation.z + 90f));
            angle -= sectorDegree;
        }
    }
    
    public void Attack(int power, PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.Sin:
                if (power < 10f)
                {
                    sinShipFirstAttack();
                }
                else if (power < 20f)
                {
                    sinShipSecondAttack(xInterval, 0f);
                }
                else if (power < 30f)
                {
                    sinShipThirdAttack();
                }
                else if (power == 30f)
                {
                    sinShipFourthAttack();
                }
                break;

            case PlayerType.Ho:
                hoShipAttack(power);
                break;

            case PlayerType.Deung:
                deungShipAttack(power);
                break;

            default:
                break;
        }
    }
}
