using UnityEngine;
using System.Collections;
using System;

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

    [SerializeField]
    int attackMaxCount;
    int attackCount;

    float fireRate;
    float timeRate = 0.0f;


    [SerializeField]
    private GameObject[] playerModel;

    [SerializeField]
    GameObject barrier;

    SubAttackCtrl subAttackCtrl;
    MainAttackCtrl mainAttackCtrl;
    GuaidanceMove homingMove;

    [SerializeField]
    float invincibleTime = 3f;
    bool invincible;
    float countTime;
    private void Start()
    {

        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        subAttackCtrl = FindObjectOfType<SubAttackCtrl>();
        barrier.SetActive(false);
        mainAttackCtrl = gameObject.GetComponentInChildren<MainAttackCtrl>();
        GameMediator.Instance.changePower += new GameMediator.ChangePower(ChangeDeungShipFireRate);

    }

    private void Update()
    {
        if (attacking)
        {
            Attack();
            if (power >= 30)
                power = 30;
        }
        if (invincible)
        {
            countTime += Time.deltaTime;
            if (countTime >= invincibleTime)
            {
                invincible = false;
                countTime = 0;
            }
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
        if (timeRate <= fireRate)
        {
            timeRate += Time.deltaTime;
            return;
        }
        else if (timeRate >= fireRate)
        {
            if (playerType == PlayerType.Deung)
            {
                GameMediator.Instance.PlaySound(SoundType.PlayerAttack);
                mainAttackCtrl.Attack(power);
            }
            else
            {
                GameMediator.Instance.PlaySound(SoundType.PlayerAttack);
                mainAttackCtrl.Attack(power);
            }
            timeRate = 0.0f;
            attackCount++;
        }

        if (attackCount == attackMaxCount && playerType != PlayerType.Deung)
        {
            subAttackCtrl.Attack(power);
            attackCount = 0;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Item" && !invincible)
        {
            GameMediator.Instance.PlaySound(SoundType.PlayerHit);
            currentLife--;
            power -= 5;
            if (power < 0)
                power = 0;
            GameMediator.Instance.changeLife();
            GameMediator.Instance.changePower();
            invincible = true;
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
                barrier.SetActive(false);
                fireRate = 0.05f;
                break;
            case PlayerType.Ho:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(true);
                playerModel[2].SetActive(false);
                playerType = type;
                barrier.SetActive(false);
                fireRate = 0.1f;
                break;
            case PlayerType.Deung:
                playerModel[0].SetActive(false);
                playerModel[1].SetActive(false);
                playerModel[2].SetActive(true);
                playerType = type;
                barrier.SetActive(true);
                fireRate = 0.5f;
                break;

            default:
                break;
        }
        mainAttackCtrl.playerType = playerType;
        subAttackCtrl.playerType = playerType;
    }

    public void ChangeDeungShipFireRate()
    {
        if (playerType == PlayerType.Deung)
        {
            if (power >= 10)
                fireRate = 0.4f;
            if (power >= 20)
                fireRate = 0.35f;
            if (power >= 30)
                fireRate = 0.3f;
        }

    }

    public void EndGame()
    {
        power = 0;
        currentLife = maxLife;
    }

}
