using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUICtrl : MonoBehaviour
{
    InputManager inputManager;
    [SerializeField]
    ScrollRect ScrollPanel;

    public int SalePrice;
   
    public Image ScrolledImage;

    private void Start()
    {
        
        inputManager = FindObjectOfType<InputManager>();
        ScrolledImage = gameObject.GetComponentInChildren<Image>();
        ScrollPanel = gameObject.GetComponent<ScrollRect>();
        
    }
    

    public void OnTradePowerItem()
    {
        
       if (ScrollPanel.horizontalNormalizedPosition > 0.7)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            inputManager.BuyItem(Item.PowerItem); 
        }
    }

    public void OnTradeLifeItem()
    {
        
        if (ScrollPanel.horizontalNormalizedPosition > 0.7)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            inputManager.BuyItem(Item.LifeItem);  
        }
    }

    public void OnTradePowerRegenItem()
    {
        
        if (ScrollPanel.horizontalNormalizedPosition > 0.7)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            inputManager.BuyItem(Item.PowerRegenItem);
        }
    }

    public void TradeMagnaticItem()
    {
     
        if (ScrollPanel.horizontalNormalizedPosition > 0.7)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            inputManager.BuyItem(Item.MagnaticItem);
        }
    }

}
