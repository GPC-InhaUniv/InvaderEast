using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// </summary>

public class Player : Character
{
    IMainAttackable mainAttack;
    ISubAttackable subAttack;
    Guaidance guaidance;
    int attackCount;

    private void Start()
    {
        //gameMediator.SetPlayer();
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        //guaidance = FindObjectOfType<Guaidance>();
        mainAttack = FindObjectOfType<Straight>();
        subAttack = FindObjectOfType<Guaidance>();
    }

    private void Update()
    {
        if (attacking)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        //공격 관련 프리펩은 나중에 하나의
        //오브젝트에 모아놓기로 결정
        mainAttack.Attack(damage);
        if(attackCount==3)
        {
            subAttack.Attack(damage);
            attackCount = 0;
        }
        else if(attackCount<3)
        {
            attackCount++;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {

        }

        if(other.tag=="EnemyBullet" || other.tag=="Enemy")
        {

        }
    }
}
