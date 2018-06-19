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
    [SerializeField]
    PlayerType playerType;
    int attackCount;
    float fireRate = 0.2f;
    float timeRate = 0.0f;
    float reloadAmmo = 2.0f;
    float reloadTime = 0.0f;
    bool fire = false;
    int magazine;
    [SerializeField]
    int maxMagazine = 2;
    int magazineAddCount;
    //Straight st;
    //Guaidance gu;
    [SerializeField]
    private GameObject [] playerModel;

    
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        magazine = maxMagazine;
        //st = FindObjectOfType<Straight>();
        //gu = FindObjectOfType<Guaidance>();
     
    }

    private void Update()
    {
        if (attacking)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = playerDirection * moveSpeed;
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, zMin, zMax)
        );
        rigidbody.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.x * -tilt);
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
            //EquipMainAttack(st);
            //mainAttackCtrl.Attack(power,playerType);
            if(playerType==PlayerType.Deung)
            {
                Debug.Log("플레이어 타입 확인 : " + playerType);
                AmmoSpendOrReload();
            }
            timeRate = 0.0f;
            attackCount++;
        }

        if(attackCount==3)
        {
            //EquipSubAttack(gu);
            //subAttack.Attack(power,playerType);
            Debug.Log("보조 무장 작동 확인");
            attackCount = 0;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Item")
        {
            Item itemType = other.GetComponent<Item>();
            gameMediator.GetItem(itemType.ItemType);
            AddAmmo();
        }

        if(other.tag=="EnemyBullet" || other.tag=="Enemy")
        {

        }
    }

    /*public void EquipMainAttack(IMainAttackable MainWeapon)
    {

        if (MainWeapon is Straight)
        {
            mainAttackCtrl = FindObjectOfType<Straight>();
        }
    }*/
    /*public void EquipSubAttack(ISubAttackable SubWeapon)
    {
        if (SubWeapon is Guaidance)
        {
            subAttack = FindObjectOfType<Guaidance>();
        }
    }*/
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
                playerType = type;
                break;
            case PlayerType.Ho:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(true);
                playerModel[2].SetActive(false);
                playerType = type;
                break;
            case PlayerType.Deung:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(false);
                playerModel[2].SetActive(true);
                playerType = type;
                break;
            
            default:
                break;
        }
    }

    public void AddAmmo()
    {
        if(maxMagazine<5)
        {
            magazineAddCount++;
        }
        if(magazineAddCount==10 && power<=30)
        {
            magazineAddCount = 0;
            maxMagazine++;
        }
        else if(power==30)
        {
            return;
        }
    }

    public void AmmoSpendOrReload()
    {
        if(magazine>0)
        {
            --magazine;
            Debug.Log("남은 잔탄 수 확인 : " + magazine);
            attackCount++;
        }
        else if(reloadTime<=reloadAmmo)
        {
            reloadTime += Time.deltaTime;
            Debug.Log("재장전 대기 시간 확인 : " + reloadTime);
            return;
        }
        else if(reloadTime>=reloadAmmo)
        {
            Debug.Log("재장전 대기 시간 종료");
            magazine = maxMagazine;
            Debug.Log("재장전 장탄 수 확인 : " + magazine);
            reloadTime = 0.0f;
        }
    }
}
