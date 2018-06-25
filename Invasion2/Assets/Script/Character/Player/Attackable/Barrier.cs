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

    [SerializeField]
    GameObject barrierImage;

    private void Start()
    {
        barrierCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        barrierImage.SetActive(true);
    }
    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(ShieldRecharge());
        barrierCollider.enabled = false;
        barrierImage.SetActive(false);
    }

    public IEnumerator ShieldRecharge()
    {
        yield return new WaitForSeconds(CoolTime);
        barrierCollider.enabled = true;
        barrierImage.SetActive(true);
    }

    private void OnDisable()
    {
        barrierImage.SetActive(false);
    }
}
