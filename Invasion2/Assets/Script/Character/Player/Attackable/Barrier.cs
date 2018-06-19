using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    /// <summary>
    /// 작성자 : 이재환
    /// 적 공격을 맞으면 배리어 비활성화
    /// 배리어의 쿨타임 시간 (코루틴)
    /// </summary>
    public GameObject barrier;

    [SerializeField]
    const float CoolTime = 3.0f;

    void Start()
    {

    }

    public void Attack(int power, PlayerType playerType)
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyBullet")
        {
            barrier.SetActive(false);
            Debug.Log("충돌?");
            StartCoroutine(ShieldRecharge());
        }

    }

    IEnumerator ShieldRecharge()
    {
        yield return new WaitForSeconds(CoolTime);
        barrier.SetActive(true);
    }
}