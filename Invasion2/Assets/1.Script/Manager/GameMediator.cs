using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// 각 싱글톤들의 중재자.
/// </summary>
public class GameMediator : Singleton<GameMediator>
{
    Player player;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        SoundManager.Instance.PlayBackgroundSound();
    }

    //게임 데이터와 플레이어의 데이터 읽기
    public int ReadPlayerGold()
    {
        return GameDataManager.Instance.Gold;
    }
    public int ReadPlayerMaxScore()
    {
        return GameDataManager.Instance.MaxScore;
    }
    public int ReadCurrentScore()
    {
        return GameDataManager.Instance.CurrentScore;
    }
    public int ReadPlayerPower()
    {
        return player.Power;
    }
    public int ReadPlayerLife()
    {
        return player.CurrentLife;
    }
    public PlayerType ReadPlayerType()
    {
        return player.PlayerType;
    }

    public delegate void DoChangeScoreDelegate();
    public DoChangeScoreDelegate CheckedChangeScore;
    public void ChangeScore(int score)
    {
        GameDataManager.Instance.ChangeScore(score);
        if (CheckedChangeScore != null)
            CheckedChangeScore();
    }
    public void ChangeMaxScore(int score)
    {
        GameDataManager.Instance.ChangeMaxScore(score);
    }
    public void ChangePlayerMaxLife(int life)
    {
        player.MaxLife += life;
    }
    public delegate void DoChangeGoldDelegate();
    public DoChangeGoldDelegate CheckedChangeGold;
    public void ChangeGold(int gold)
    {
        GameDataManager.Instance.ChangeGold(gold);
        if (CheckedChangeGold != null)
            CheckedChangeGold();
    }

    public delegate void DoGameOverDelegate();
    public DoGameOverDelegate DoGameOver;
    public void GameOver()
    {
        if (DoGameOver != null)
            DoGameOver();
        player.EndGame();
        if (changeLife != null)
            changeLife();
        if (changePower != null)
            changePower();
        if (CheckedChangeGold != null)
            CheckedChangeGold();
    }

    // count : 골드, 스코어 아이템의 골드량 및 스코어양
    public void GetItem(ItemType item, int count)
    {
        ItemManager.Instance.GetItem(item, count);
    }
    public void GetItem(ItemType item)
    {
        ItemManager.Instance.GetItem(item);
    }

    public void BuyItem(ItemType item)
    {
        ItemManager.Instance.BuyItem(item);
    }

    public void SellItem(ItemType item)
    {
        ItemManager.Instance.SellItem(item);
    }


    // 캐릭터 파워,최대 체력, 장비, 모델 변경
    public delegate void DoChangePowerDelegate();
    public DoChangePowerDelegate changePower;
    public void ChangePlayerPower(int count)
    {
        player.Power += count;
        if (changePower != null)
            changePower();
    }
    public delegate void DoChangeLifeDelegate();
    public DoChangeLifeDelegate changeLife;
    public void ChangePlayerLife(int count)
    {
        if (player.CurrentLife < player.MaxLife)
            player.CurrentLife += count;
        if (changeLife != null)
            changeLife();
    }

    public void ChangePlayerType(PlayerType type)
    {
        player.ChangePlayer(type);
    }

    //InputManager에서 플레이어 이동 방향 받아오기
    public void PlayerMove(Vector3 direction)
    {
        player.DirectionToMove(direction);
    }
    public void PlayerAttack(bool CheckedAttack)
    {
        player.Attacking = CheckedAttack;
    }

    public void ChangeScene(SceneState state)
    {
        SceneController.Instance.ChangeScene(state);
    }

    public void SpawnItem(GameObject enemyPos)
    {
        ItemManager.Instance.SpawnItem(enemyPos);
    }
    public void PlaySound(SoundType soundType)
    {
        SoundManager.Instance.PlayEffectSound(soundType);
    }

    //pool manager 관련 메서드

    public GameObject GetEnemyObjectFromPool()
    {
        return PoolManager.Instance.GetEnemyObject();
    }

    public void PutEnemyObjectAtPool(GameObject gameObject)
    {
        PoolManager.Instance.PutEnemyObject(gameObject);
    }

    public GameObject GetEnemyBulletFromPool()
    {
        return PoolManager.Instance.GetEnemyBulletObject();
    }

    public void PutEnemyBulletAtPool(GameObject gameObject)
    {
        PoolManager.Instance.PutEnemyBulletObject(gameObject);
    }

    public GameObject GetPlayerBulletFromPool()
    {
        return PoolManager.Instance.GetPlayerBulletObject();
    }

    public void PutPlayerBulletAtPool(GameObject gameObject)
    {
        PoolManager.Instance.PutPlayerBulletObject(gameObject);
    }

    
    public GameObject GetPlayerSpreadBulletFromPool()
    {
        return PoolManager.Instance.GetPlayerSpreadBulletObject();
    }

    public void PutPlayerSpreadBulletAtPool(GameObject gameObject)
    {
        PoolManager.Instance.PutPlayerSpreadBulletObject(gameObject);
    }

    public GameObject GetPlayerMissileFromPool(PlayerType type)
    {
        return PoolManager.Instance.GetPlayerMissileObject(type);
    }

    public void PutPlayerMissileAtPool(GameObject gameObject, PlayerType type)
    {
        PoolManager.Instance.PutPlayerMissileObject(gameObject, type);
    }
    public GameObject GetItemObjectFromPool()
    {
        return PoolManager.Instance.GetItemObject();
    }
    public void PutItemObjectAtPool(GameObject gameObject)
    {
        PoolManager.Instance.PutItemObject(gameObject);
    }


}
