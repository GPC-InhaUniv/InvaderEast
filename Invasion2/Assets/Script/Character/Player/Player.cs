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
        mainAttack = new Straight();
    }

    public override void Attack()
    {
        mainAttack.Attack(10);
        subAttack.Attack(10);
    }

    public override void OnTriggerEnter(Collider other)
    {

    }
}
