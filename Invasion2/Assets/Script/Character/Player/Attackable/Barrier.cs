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
    Player player;

    [SerializeField]
    const float CoolTime = 3.0f;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyBullet" || collider.tag == "Enemy")
        {
            Debug.Log("충돌?");
            gameObject.SetActive(false);
            StartCoroutine(player.ShieldRecharge());
        }

    }
}
