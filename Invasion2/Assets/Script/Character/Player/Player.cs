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
    float fireRate = 0.2f;
    float timeRate = 0.0f;
    bool fire = false;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        //guaidance = FindObjectOfType<Guaidance>();
       
     
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
        if(timeRate<fireRate)
        {
            timeRate += Time.deltaTime;
            return;
        }
        else if(timeRate>=fireRate)
        {
            mainAttack.Attack(damage);
            timeRate = 0.0f;
            attackCount++;
        }
            
        
        if(attackCount==3)
        {
           // subAttack.Attack(damage);
            attackCount = 0;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {
            Item itemType = other.GetComponent<Item>();
            gameMediator.GetItem(itemType.ItemType);  
        }

        if(other.tag=="EnemyBullet" || other.tag=="Enemy")
        {

        }
    }

    public void EquipMainAttack(IMainAttackable MainWeapon)
    {

        if (MainWeapon is Straight)
        {
            mainAttack = FindObjectOfType<Straight>();
        }
    }
    public void EquipSubAttack(ISubAttackable SubWeapon)
    {
        if (SubWeapon is Guaidance)
        {
            subAttack = FindObjectOfType<Guaidance>();
        }
    }
}
