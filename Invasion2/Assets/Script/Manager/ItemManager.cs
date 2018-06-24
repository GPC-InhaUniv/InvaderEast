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
    private int powerItemCount;
    private int lifeItemCount;
    private bool magnaticItem;
    private bool powerRegenItem;

    [SerializeField]
    int incresePower;


    public bool PowerRegenItem { get { return powerRegenItem; }}
    public bool MagnaticItem { get { return magnaticItem; } }

    private void Start()
    {     
        powerItemCount = 0;
        lifeItemCount = 0;
        magnaticItem = false;
        powerRegenItem = false;
        incresePower = 2;
    }

    public void GetItem(ItemType item)
    {
        switch (item)
        {
            case ItemType.PowerItem:
                powerItemCount += 3;
                GameMediator.Instance.ChangePlayerPower(powerItemCount);
                break;
            case ItemType.LifeItem:
                lifeItemCount += 1;
                GameMediator.Instance.ChangePlayerLife(lifeItemCount);
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
                powerItemCount += 10;
       
                GameMediator.Instance.ChangePlayerPower(10);
                break;
            case ItemType.LifeItem:
                lifeItemCount += 10;
        
                GameMediator.Instance.ChangePlayerLife(10);
                break;
            case ItemType.MagnaticItem:
                magnaticItem = true;
                break;
            case ItemType.PowerRegenItem:
                powerRegenItem = true;
                incresePower += 1;
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
                powerItemCount -= 10;
          
                GameMediator.Instance.ChangePlayerPower(-10);
                break;
            case ItemType.LifeItem:
                lifeItemCount -= 10;
       
                GameMediator.Instance.ChangePlayerLife(-10);
                break;
            case ItemType.MagnaticItem:
                magnaticItem = false;
                break;
            case ItemType.PowerRegenItem:
                powerRegenItem = false;
                incresePower += 1;
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
