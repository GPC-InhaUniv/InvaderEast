using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spread : MonoBehaviour
{
    const int spreadCount = 10;
    const int maxAngle = 360;
    int angle;
    [SerializeField]
    GameObject playerBullet;

    private void Start()
    {
        //StartCoroutine(bulletSpread());

        Invoke("bulletSpread", 0.5f);
    }

    public void bulletSpread()
    {
        Debug.Log("불림");
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
        angle = maxAngle / spreadCount;
        for (int i = 0; i < spreadCount; i++)
        {
            playerBullet = PoolManager.Instance.GetPlayerBulletObject();
            playerBullet.transform.position = transform.position;
            playerBullet.transform.rotation = Quaternion.Euler(0f, angle * i, 0f);
            

        }
        
    }
    /*
    public IEnumerator bulletSpread()
    {
        yield return new WaitForSeconds(0.5f);
        angle = maxAngle / spreadCount;
        for (int i = 0; i < spreadCount; i++)
        {
            playerBullet = PoolManager.Instance.GetPlayerBulletObject();
            playerBullet.transform.position = transform.position;
            playerBullet.transform.rotation = Quaternion.Euler(0f, angle * i, 0f);
        }
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }*/
}
