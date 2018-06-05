using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// </summary>

public class Player : Character
{
    IMainAttackable mainAttack;
    ISubAttackable subAttack;

    private void Start()
    {
        //gameMediator.SetPlayer();
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        //mainAttack = new Straight();
    }

    public override void Attack()
    {
        // 공격 프리펩 로드 관련 미구현으로
        // 인터페이스 공격 메서드 부를시 에러 발생
        // MoveController 에서 구현한 조이스틱 먹통
        /*mainAttack.Attack(10);
        subAttack.Attack(10);*/
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
