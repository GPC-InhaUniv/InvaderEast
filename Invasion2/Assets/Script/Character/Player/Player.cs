using UnityEngine;

/// <summary>
/// 담당자 : 박상원
/// --------------------------------------------------
/// Character를 상속받아
/// MoveController 스크립트에서 이동 방향을
/// Move 메서드의 매개변수에 전달해주면서
/// Player의 공격을 활성화하여 이동과 함께
/// 공격을 하도록 하였습니다.
/// --------------------------------------------------
/// CharacterSelectSceneCtrl 스크립트에서
/// 캐릭터 선택 씬 화면에서 플레이어 캐릭터 선택시
/// 선택된 캐릭터 타입을 InputManager에 알려주고
/// InputManager에서 GameMediator에 전달하여
/// Character 스크립트를 상속받은 Player 스크립트에
/// 정의되어 있는 ChangePlayer 메서드로 전달되어
/// 게임 화면에 표시해줄 플레이어 캐릭터를 활성화한다.
/// --------------------------------------------------
/// 스크립트 주석친 부분은 최근 무기 발사와 관련하여
/// 테스트 하기 위해 남겨둔 코드입니다.
/// --------------------------------------------------
/// </summary>

public class Player : Character
{
    IMainAttackable mainAttack;
    ISubAttackable subAttack;
    int attackCount;
    float fireRate = 0.2f;
    float timeRate = 0.0f;
    bool fire = false;
    Straight st;
    Guaidance gu;
    [SerializeField]
    private GameObject [] playerModel;

    private void FixedUpdate()
    {
        rigidbody.velocity = playerDirection * moveSpeed;
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            Mathf.Clamp(rigidbody.position.y, yMin, yMax),
            0.0f
        );
        rigidbody.rotation = Quaternion.Euler(0.0f, rigidbody.velocity.x * -tilt, 0.0f);
    }
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        st = FindObjectOfType<Straight>();
        gu = FindObjectOfType<Guaidance>();
     
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
            EquipMainAttack(st);
            mainAttack.Attack(damage);
            timeRate = 0.0f;
            attackCount++;
        }
            
        
        if(attackCount==3)
        {
            EquipSubAttack(gu);
             subAttack.Attack(damage);
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
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
        {

        }
    }

    public void ChangePlayer(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Sin:
                playerModel[0].SetActive(true);
                playerModel[1].SetActive(false);
                playerModel[2].SetActive(false);
                break;
            case PlayerType.Ho:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(true);
                playerModel[2].SetActive(false);
                break;
            case PlayerType.Deung:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(false);
                playerModel[2].SetActive(true);
                break;
            
            default:
                break;
        }
    }
}
