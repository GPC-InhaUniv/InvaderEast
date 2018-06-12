using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUICtrl : MonoBehaviour
{

    [SerializeField]
    ScrollRect ScrollPanel;

    [SerializeField]
    Text PlayerGold;
    public int SalePrice;

    bool purchase;
    private void Start()
    {

        ScrollPanel = gameObject.GetComponentInChildren<ScrollRect>();
        PlayerGold.text = InputManager.Instance.ReadPlayerGold().ToString();


    }



    public void OnTradePowerItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;

            if (InputManager.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("Power Item 구입");
                purchase = true;
                InputManager.Instance.BuyItem(ItemType.PowerItem, SalePrice);
            }

        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("Power Item 판매");
            purchase = false;
            InputManager.Instance.SellItem(ItemType.PowerItem, SalePrice);

        }

    }

    public void OnTradeLifeItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;

            if (InputManager.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("LifeItem 구입!");
                purchase = true;
                InputManager.Instance.BuyItem(ItemType.LifeItem, SalePrice);
            }

        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("LifeItem 판매");
            purchase = false;
            InputManager.Instance.SellItem(ItemType.LifeItem, SalePrice);

        }

    }

    public void OnTradePowerRegenItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;

            if (InputManager.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("PowerRegenItem 구입!");
                purchase = true;
                InputManager.Instance.BuyItem(ItemType.PowerRegenItem, SalePrice);
            }

        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("PowerRegenItem 판매");
            purchase = false;
            InputManager.Instance.SellItem(ItemType.PowerRegenItem, SalePrice);

        }

    }

    public void OnTradeMagnaticItem()
    {


        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;

            if (InputManager.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("MagnaticItem 구입!");
                purchase = true;
                InputManager.Instance.BuyItem(ItemType.MagnaticItem, SalePrice);
            }
        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("MagnaticItem 판매");
            purchase = false;
            InputManager.Instance.SellItem(ItemType.MagnaticItem, SalePrice);
        }

    }

}
