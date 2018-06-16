using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spread : MonoBehaviour
{
    const int spreadCount = 8;
    const int maxAngle = 360;
    int angle;

    public IEnumerator bulletSpread()
    {
        GameObject bullet;
        angle = maxAngle / spreadCount;
        for (int i = 0; i < spreadCount; i++)
        {
            bullet = Instantiate(gameObject,transform.position,Quaternion.Euler(0f,0f, angle * i));
        }
        yield break;
    }
}
