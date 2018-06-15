using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 담당자 : 김지섭

// 브릿지 패턴 중에 Implementor 부분입니다

interface IEnemyShotPattern
{
    IEnumerator ShootStraight();
    IEnumerator ShootFiveTimes();
    IEnumerator ShootInductionBullet();
    IEnumerator ShootTwoinNumber();
    IEnumerator ShootFanwise();

}
