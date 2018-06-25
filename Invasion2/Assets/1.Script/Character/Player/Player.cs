using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 담당자 : 박상원
/// --------------------------------------------------
/// CharacterSelectSceneCtrl 에서 PlayerType을 전달해주면
/// 해당 PlayerType에 맞춰 플레이어 캐릭터를 활성화.
/// --------------------------------------------------
/// 터치 이동 여부를 확인하여 공격을 On / Off 한다.
/// 각 플레이어 캐릭터의 탄막 발사 간격 등의 기능도
/// Player 스크립트에서 담당한다.
/// --------------------------------------------------
/// </summary>

public class Player : Character
{
    [SerializeField]
    PlayerType playerType;

    public PlayerType PlayerType { get { return playerType; } }
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
        currentLife = maxLife;
        DontDestroyOnLoad(gameObject);
        rigidbody = GetComponent<Rigidbody>();
        subAttackCtrl = FindObjectOfType<SubAttackCtrl>();
        barrier.SetActive(false);
        mainAttackCtrl = gameObject.GetComponentInChildren<MainAttackCtrl>();
        GameMediator.Instance.changePower += new GameMediator.DoChangePowerDelegate(ChangeDeungShipFireRate);

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
