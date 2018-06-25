using UnityEngine;
/// <summary>
/// 담장자 : 이재환
/// -------------------------------
/// 캐릭터들의 서브공격을 제어 
/// HomingMissile : 유도 미사일  
/// StraightMissile : 직선형 미사일
/// -------------------------------
/// </summary>
public class SubAttackCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject straightMissile;

    [SerializeField]
    GameObject homingMissile;

    GuaidanceMove homingMove;

    public PlayerType playerType;

    void HomingMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        homingMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Sin);
        homingMissile.transform.position = rightSpawnPos;

        homingMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Sin);
        homingMissile.transform.position = leftSpawnPos;

    }

    void StraightMissile()
    {
        Vector3 rightSpawnPos = transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        Vector3 leftSpawnPos = transform.position + new Vector3(-0.5f, 0.0f, 0.0f);

        straightMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Ho);
        straightMissile.transform.position = rightSpawnPos;

        straightMissile = PoolManager.Instance.GetPlayerMissileObject(PlayerType.Ho);
        straightMissile.transform.position = leftSpawnPos;

    }

    public void Attack(int power)
    {
        switch (playerType)
        {
            case PlayerType.Sin:
                HomingMissile();
                break;
            case PlayerType.Ho:
                StraightMissile();
                break;
            default:
                break;
        }
    }
}
