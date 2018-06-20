using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    /// <summary>
    /// 작성자 : 이재환
    /// 적 공격을 맞으면 배리어 비활성화
    /// 배리어의 쿨타임 시간 (코루틴)
    /// </summary>
    //public GameObject barrier;


    Player player;
    [SerializeField]
    const float CoolTime = 3.0f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "EnemyBullet")
        {
            player.RegenBarrier();
            Debug.Log("충돌?");
        }
    }
}