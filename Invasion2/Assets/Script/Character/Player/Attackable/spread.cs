using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spread : MonoBehaviour
{
    const int spreadCount = 10;
    const int maxAngle = 360;
    int angle;
    [SerializeField]
    GameObject bulletPrefab;
    private void Start()
    {
        StartCoroutine(bulletSpread());
    }

    public IEnumerator bulletSpread()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bullet;
        angle = maxAngle / spreadCount;
        for (int i = 0; i < spreadCount; i++)
        {
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, angle * i, 0f));
        }
    }
}
