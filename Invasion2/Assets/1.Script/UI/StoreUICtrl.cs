using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 담당자 : 김정수
/// 
/// Store UI중 슬라이드 되어지는 이미지와 그에따른 아이템 구매 및 판매 처리
/// StoreUI스크립트와 결합이 필요하다.
/// </summary>
public class StoreUICtrl : MonoBehaviour
{

    [SerializeField]
    ScrollRect ScrollPanel;

    [SerializeField]
    Text PlayerGold;
    public int SalePrice;

    private bool purchase;
    [SerializeField]
    private Sprite UnvailableItem;
    [SerializeField]
    private Sprite AvailableItem;
    [SerializeField]
    private Image ScrolledImage;


    private void Start()
    {
        ScrollPanel = gameObject.GetComponentInChildren<ScrollRect>();
        ShowChange();
        GameMediator.Instance.CheckedChangeGold += new GameMediator.DoChangeGoldDelegate(ShowChange);
    }

    private void ShowChange()
    {
        PlayerGold.text = GameMediator.Instance.ReadPlayerGold().ToString();
        if (GameMediator.Instance.ReadPlayerGold() < SalePrice)
            {
                ScrolledImage.sprite = UnvailableItem;
            }
            else
            {
                ScrolledImage.sprite = AvailableItem;
            }
        
    }

    public void OnTradePowerItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            if (GameMediator.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("Power Item 구입");
                purchase = true;
                GameMediator.Instance.ChangeGold(-SalePrice);
                GameMediator.Instance.BuyItem(ItemType.PowerItem);

            }
        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("Power Item 판매");
            purchase = false;
            GameMediator.Instance.ChangeGold(SalePrice);
            GameMediator.Instance.SellItem(ItemType.PowerItem);

        }
    }
    public void OnTradeLifeItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            if (GameMediator.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
               
                purchase = true;
                GameMediator.Instance.ChangeGold(-SalePrice);
                GameMediator.Instance.BuyItem(ItemType.LifeItem);

            }

        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("LifeItem 판매");
            purchase = false;
            GameMediator.Instance.ChangeGold(SalePrice);
            GameMediator.Instance.SellItem(ItemType.LifeItem);

        }
    }
    public void OnTradePowerRegenItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;
            if (GameMediator.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("PowerRegenItem 구입!");
                purchase = true;
                GameMediator.Instance.ChangeGold(-SalePrice);
                GameMediator.Instance.BuyItem(ItemType.PowerRegenItem);

            }
        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("PowerRegenItem 판매");
            purchase = false;
            GameMediator.Instance.ChangeGold(SalePrice);
            GameMediator.Instance.SellItem(ItemType.PowerRegenItem);

        }

    }
    public void OnTradeMagnaticItem()
    {

        if (ScrollPanel.horizontalNormalizedPosition > 0.8)
        {
            ScrollPanel.horizontalNormalizedPosition = 1;

            if (GameMediator.Instance.ReadPlayerGold() >= SalePrice && !purchase)
            {
                Debug.Log("MagnaticItem 구입!");
                purchase = true;
                GameMediator.Instance.ChangeGold(-SalePrice);
                GameMediator.Instance.BuyItem(ItemType.MagnaticItem);

            }
        }
        else if (ScrollPanel.horizontalNormalizedPosition < 0.8 && purchase)
        {
            Debug.Log("MagnaticItem 판매");
            purchase = false;
            GameMediator.Instance.ChangeGold(SalePrice);
            GameMediator.Instance.SellItem(ItemType.MagnaticItem);
           
        }
    }
    private void OnDestroy()
    {
        GameMediator.Instance.CheckedChangeGold -= new GameMediator.DoChangeGoldDelegate(ShowChange);
    }
}
