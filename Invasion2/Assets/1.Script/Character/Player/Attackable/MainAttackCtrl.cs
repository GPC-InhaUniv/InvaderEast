using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 담당자 : 이재환
/// 플레이어의 메인공격 부분
/// -----------------------------------
/// DeungShipAttack : 산탄 총알 공격
/// SinShipAttack : 직선 으로 가는 탄
/// HoShipAttack : 부채꼴 모양의 탄
/// ------------------------------------
/// </summary>
public class MainAttackCtrl : MonoBehaviour
{
    const float xInterval = 0.22f;

    const float yInterval = -0.5f;

    const float sectorDegree = 3f;

    GameObject playerBullet;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject SpreadPrefab;

    [SerializeField]
    GameObject shotPosition;

    public PlayerType playerType;

    void DeungShipAttack()
    {
        playerBullet = PoolManager.Instance.GetPlayerSpreadBulletObject();
        playerBullet.transform.position = shotPosition.transform.position;
    }

    void SinShipFirstAttack()
    {
        playerBullet = PoolManager.Instance.GetPlayerBulletObject();
        playerBullet.transform.position = shotPosition.transform.position;

    }

    void SinShipSecondAttack(float xPosition, float yPosition)
    {
        Vector3 positionR = new Vector3(xPosition, 0, yPosition);
        Vector3 positionL = new Vector3(-xPosition, 0, yPosition);

        playerBullet = PoolManager.Instance.GetPlayerBulletObject();
        playerBullet.transform.position = shotPosition.transform.position + positionL;

        playerBullet = PoolManager.Instance.GetPlayerBulletObject();
        playerBullet.transform.position = shotPosition.transform.position + positionR;

    }

    void SinShipThirdAttack()
    {
        SinShipFirstAttack();
        SinShipSecondAttack(xInterval, yInterval);
    }

    void SinShipFourthAttack()
    {
        SinShipSecondAttack(xInterval, yInterval);
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
            playerBullet = PoolManager.Instance.GetPlayerBulletObject();

            playerBullet.transform.position = shotPosition.transform.position;

            playerBullet.transform.rotation = Quaternion.Euler(shotPosition.transform.rotation.x,
                    shotPosition.transform.rotation.y + angle, shotPosition.transform.rotation.z);

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
