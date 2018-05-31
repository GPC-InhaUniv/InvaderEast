using UnityEngine;


public enum Item
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
    public GameMediator gameMediator;
    public int PowerItemCount;
    public int LifeItemCount;
    public bool MagnaticItem;
    public bool PowerRegenItem;
   
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        PowerItemCount = 0;
        LifeItemCount = 0;
        MagnaticItem = false;
        PowerRegenItem = false;
    }

    public void GetItem(Item item)
    {
        switch (item)
        {
            case Item.PowerItem:
                PowerItemCount += 1;
                break;
            case Item.LifeItem:
                LifeItemCount += 1;
                break;
           
            default:
                break;
        }
    }
    public void GetItem(Item item, int count)
    {
        switch (item)
        {
            case Item.GoldItem:
                gameMediator.ChangeGold(count);
                break;
            case Item.ScoreItem:
                gameMediator.ChangeScore(count);
                break;
            default:
                break;
        }
    }
    
    public void BuyItem(Item item)
    {
        switch(item)
        {
            case Item.PowerItem:
                PowerItemCount += 10;
                break;
            case Item.LifeItem:
                LifeItemCount += 10;
                break;
            case Item.MagnaticItem:
                MagnaticItem = true;
                break;
            case Item.PowerRegenItem:
                PowerRegenItem = true;
                break;
            default:
                break;
        }
    }

    public void SellItem(Item item)
    {
        switch (item)
        {
            case Item.PowerItem:
                PowerItemCount -= 10;
                break;
            case Item.LifeItem:
                LifeItemCount -= 10;
                break;
            case Item.MagnaticItem:
                MagnaticItem = false;
                break;
            case Item.PowerRegenItem:
                PowerRegenItem = false;
                break;
            default:
                break;
        }
    }
}
