using System.Collections;
using UnityEngine;
/// <summary>
/// 담당자 : 이재환
/// -----------------------------
/// 산탄 총의 탄 효과 부분
/// -----------------------------
/// </summary>
public class spread : MonoBehaviour
{
    const int spreadCount = 24;
    const int maxAngle = 120;
    int angle;
        
    [SerializeField]
    GameObject shotPosition;

    private void Start()
    {
        StageManager.Instance.restart += new Restart(ReturnPool);
    }

    private void OnEnable()
    {
      StartCoroutine(BulletSpread());
    }
        
    public IEnumerator BulletSpread()
    {
        yield return new WaitForSeconds(1f);
        angle = maxAngle / spreadCount;

        for (int i = -spreadCount / 2; i < spreadCount/2; i++)
        {
            GameObject playerBullet;
            playerBullet = PoolManager.Instance.GetPlayerBulletObject();
            shotPosition.transform.rotation = Quaternion.Euler(0f, angle * i, 0f);
            playerBullet.transform.position = shotPosition.transform.position;
            playerBullet.transform.rotation = shotPosition.transform.rotation;
            
        }
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }

    public void ReturnPool()
    {
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }

    private void OnDisable()
    {

    }

    private void OnDestroy()
    {
        StageManager.Instance.restart -= new Restart(ReturnPool);
    }
}
