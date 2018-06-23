using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spread : MonoBehaviour
{
    const int spreadCount = 10;
    const int maxAngle = 300;
    int angle;



    [SerializeField]
    GameObject shotPosition;

    private void Start()
    {

    }

    private void OnEnable()
    {
      StartCoroutine(BulletSpread());
    }
        
    public IEnumerator BulletSpread()
    {
        yield return new WaitForSeconds(1f);
        angle = maxAngle / spreadCount;

        for (int i = 0; i < spreadCount; i++)
        {
            GameObject playerBullet;
            playerBullet = PoolManager.Instance.GetPlayerBulletObject();
            shotPosition.transform.rotation = Quaternion.Euler(0f, angle * i, 0f);
            playerBullet.transform.position = shotPosition.transform.position;
            playerBullet.transform.rotation = shotPosition.transform.rotation;
            // Debug.Log(angle * i);
            //playerBullet.transform.rotation = Quaternion.Euler(0f, 10 * i, 0f);

        }
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }
    private void OnDisable()
    {

    }
}
