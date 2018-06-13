using UnityEngine;

public class ShotEffect : MonoBehaviour
{
    /// <summary>
    /// 샷건의 총알에 충돌하면 작은 콩알탄 생성
    /// 샷건은 총알은 충돌하면 삭제
    /// </summary>

    public GameObject ShotEffected;


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Enemy")
        {
            Instantiate(ShotEffected, transform.position, Quaternion.Euler(1.0f, 1.0f, 1.0f));
        }

        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
    void Start()
    {

    }
}
