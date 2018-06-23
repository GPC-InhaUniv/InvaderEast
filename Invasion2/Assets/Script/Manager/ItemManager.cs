using UnityEngine;

/// <summary>
/// 담당자 : 김정수
/// Item의 데이터 처리
/// 상점에서 구매 및 판매한  아이템과 골드의 처리는 이곳에서.
/// 몬스터가 생성하는 아이템처리도 이곳에서 진행.
/// </summary>

public enum ItemType
{
    PowerItem,
    LifeItem,
    GoldItem,
    ScoreItem,
    MagnaticItem,
    PowerRegenItem,
}

public class ItemManager : Singleton<ItemManager>
{

    protected ItemManager() { }
   
    private int PowerItemCount;
    private int LifeItemCount;
    private bool MagnaticItem;
    private bool PowerRegenItem;
    private GameObject powerItemPrefab;
    private GameObject lifeItemPrefab;
    private GameObject goldItemPrefab;
    private GameObject scoreItemPrefab;

    private void Start()
    {
        
        PowerItemCount = 0;
        LifeItemCount = 0;
        MagnaticItem = false;
        PowerRegenItem = false;

        powerItemPrefab = Resources.Load("PowerItem") as GameObject;
        lifeItemPrefab = Resources.Load("LifeItem") as GameObject;
        goldItemPrefab = Resources.Load("GoldItem") as GameObject;
        scoreItemPrefab = Resources.Load("ScoreItem") as GameObject;
    }

    public void GetItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.PowerItem:
                PowerItemCount += 3;
                GameMediator.Instance.ChangePlayerPower(PowerItemCount);
                break;
            case ItemType.LifeItem:
                LifeItemCount += 1;
                GameMediator.Instance.ChangePlayerLife(LifeItemCount);
                break;

            default:
                break;
        }
    }
    public void GetItem(ItemType item, int count)
    {
        switch (item)
        {
            case ItemType.GoldItem:
                GameMediator.Instance.ChangeGold(count);
                break;
            case ItemType.ScoreItem:
                GameMediator.Instance.ChangeScore(count);
                break;
            default:
                break;
        }
    }

    public void BuyItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.PowerItem:
                PowerItemCount += 10;
                GameMediator.Instance.ChangePlayerPower(10);
                break;
            case ItemType.LifeItem:
                LifeItemCount += 10;
                GameMediator.Instance.ChangePlayerLife(10);
                break;
            case ItemType.MagnaticItem:
                MagnaticItem = true;
                break;
            case ItemType.PowerRegenItem:
                PowerRegenItem = true;
                break;
            default:
                break;
        }
    }

    public void SellItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.PowerItem:
                PowerItemCount -= 10;
                GameMediator.Instance.ChangePlayerPower(-10);
                break;
            case ItemType.LifeItem:
                LifeItemCount -= 10;
                GameMediator.Instance.ChangePlayerLife(-10);
                break;
            case ItemType.MagnaticItem:
                MagnaticItem = false;
                break;
            case ItemType.PowerRegenItem:
                PowerRegenItem = false;
                break;
            default:
                break;
        }
    }

    public void SpawnItem(GameObject enemyPos)
    {
        GameObject itemObject;
        itemObject = PoolManager.Instance.GetItemObject();
        itemObject.transform.position = enemyPos.transform.position;


    }
}
