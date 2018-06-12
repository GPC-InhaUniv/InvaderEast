﻿using UnityEngine;




public class ItemManager : Singleton<ItemManager>
{

    protected ItemManager() { }
    public GameMediator gameMediator;
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
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
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
                PowerItemCount += 1;
                gameMediator.ChangePlayerPower(PowerItemCount);
                break;
            case ItemType.LifeItem:
                LifeItemCount += 1;
                gameMediator.ChangePlayerLife(LifeItemCount);
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
                gameMediator.ChangeGold(count);
                break;
            case ItemType.ScoreItem:
                gameMediator.ChangeScore(count);
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

                gameMediator.ChangePlayerPower(10);
                break;
            case ItemType.LifeItem:
                LifeItemCount += 10;
                gameMediator.ChangePlayerLife(10);
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
                gameMediator.ChangePlayerPower(-10);
                break;
            case ItemType.LifeItem:
                LifeItemCount -= 10;
                gameMediator.ChangePlayerLife(-10);
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

    public void SpawnItem(ItemType item,Transform enemyPos)
    {
        switch (item)
        {
            case ItemType.PowerItem:
                 Instantiate(powerItemPrefab,enemyPos);
                break;
            case ItemType.LifeItem:
                Instantiate(powerItemPrefab, enemyPos);
                break;
            case ItemType.GoldItem:
                Instantiate(powerItemPrefab, enemyPos);
                break;
            case ItemType.ScoreItem:
                 Instantiate(powerItemPrefab, enemyPos);
                break;

        }

    }
}
