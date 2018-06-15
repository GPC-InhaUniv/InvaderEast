using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAttackCtrl : MonoBehaviour, IMainAttackable
{/// <summary>
/// move 스크립트 forward
/// </summary>
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    PlayerType playerType;
    [SerializeField]
    float xInterval = 0.22f;
    [SerializeField]
    float yInterval = -0.5f;

    int magazineCount;
    int maxmagazineCount;

    const float sectorDegree = 3f;
    GameObject gameObject;

    private void Start()
    {
     //   maxmagazineCount = deungShootCount();
    }

    void sinShipFirstAttack()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
    }

    void sinShipSecondAttack(float xPosition, float yPosition)
    {
        Vector3 positionR = new Vector3(xPosition, yPosition);
        Vector3 positionL = new Vector3(-xPosition, yPosition);
        Instantiate(bullet, positionL, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
        Instantiate(bullet, positionR, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 90f));
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
            angle -= sectorDegree;
        }
    }

    int deungShootCount(int power)
    {
        return (int)( Math.Truncate(power / 10f)+20);
    }

    void deungShipAttack(int power)
    {

    }

    public void Attack(int power)
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
