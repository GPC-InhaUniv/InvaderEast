using UnityEngine;
using System.Collections;
/// <summary>
/// 작성자 : 이재환
/// 적 공격을 맞으면 배리어 비활성화
/// 배리어의 쿨타임 시간 (코루틴)
/// </summary>

public class Barrier : MonoBehaviour
{
    [SerializeField]
    const float CoolTime = 3.0f;

    Collider barrierCollider;
    GameObject barrierImage;
    private void OnEnable()
    {  
    }
    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(ShieldRecharge());
        barrierCollider.enabled = false; 
    }

    public IEnumerator ShieldRecharge()
    {
        Debug.Log("실드 재생성중");
        yield return new WaitForSeconds(CoolTime);
        Debug.Log("실드 생성");
        barrierCollider.enabled = true;

    }

    private void OnDisable()
    {
        
    }
}
