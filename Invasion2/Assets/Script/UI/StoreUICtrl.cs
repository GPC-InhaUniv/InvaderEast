using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUICtrl : MonoBehaviour
{
    public InputManager inputManager;
    [SerializeField]
    ScrollRect ScrollPanel;

    [SerializeField]
    Text PlayerGold;
    public int SalePrice;

    bool purchase;
    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        ScrollPanel = gameObject.GetComponentInChildren<ScrollRect>();
        try
        {
            
           // inputManager.DelegateGold();
        }
        catch
        {
            inputManager = FindObjectOfType<InputManager>();
          //  PlayerGold.text = inputManager.ReadPlayerGold().ToString();
        }

    }
    
    public void EquipManager()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    
    public void OnTradePowerItem()
    {
        try
        {
            if (ScrollPanel.horizontalNormalizedPosition > 0.8)
            {
                ScrollPanel.horizontalNormalizedPosition = 1;
               
                if (inputManager.ReadPlayerGold()>= SalePrice && !purchase)
                {
                    Debug.Log("구입!");
                    purchase = true;
                    inputManager.BuyItem(Item.PowerItem, SalePrice);
                }
                    
            }
            else if(ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
            {
                Debug.Log("판매");
                purchase = false;
                inputManager.SellItem(Item.PowerItem, SalePrice);
                
            }
        }
        catch { EquipManager(); }
      
    }

    public void OnTradeLifeItem()
    {
        try
        {
            if (ScrollPanel.horizontalNormalizedPosition > 0.8)
            {
                ScrollPanel.horizontalNormalizedPosition = 1;

                if (inputManager.ReadPlayerGold() >= SalePrice && !purchase)
                {
                    Debug.Log("구입!");
                    purchase = true;
                    inputManager.BuyItem(Item.LifeItem, SalePrice);
                }

            }
            else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
            {
                Debug.Log("판매");
                purchase = false;
                inputManager.SellItem(Item.LifeItem, SalePrice);
                
            }
        }
        catch { EquipManager(); }
    }

    public void OnTradePowerRegenItem()
    {
        try
        {
            if (ScrollPanel.horizontalNormalizedPosition > 0.8)
            {
                ScrollPanel.horizontalNormalizedPosition = 1;

                if (inputManager.ReadPlayerGold() >= SalePrice && !purchase)
                {
                    Debug.Log("구입!");
                    purchase = true;
                    inputManager.BuyItem(Item.PowerRegenItem, SalePrice);
                }

            }
            else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
            {
                Debug.Log("판매");
                purchase = false;
                inputManager.SellItem(Item.PowerRegenItem, SalePrice);
              
            }
        }
        catch { EquipManager(); }
    }

    public void OnTradeMagnaticItem()
    {

        try
        {
            if (ScrollPanel.horizontalNormalizedPosition > 0.8)
            {
                ScrollPanel.horizontalNormalizedPosition = 1;

                if (inputManager.ReadPlayerGold() >= SalePrice && !purchase)
                {
                    Debug.Log("구입!");
                    purchase = true;
                    inputManager.BuyItem(Item.MagnaticItem, SalePrice);
                }

            }
            else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
            {
                Debug.Log("판매");
                purchase = false;
                inputManager.SellItem(Item.MagnaticItem, SalePrice);
               
            }
        }
        catch { EquipManager(); }
    }

}
