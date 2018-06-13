using UnityEngine;
using UnityEngine.UI;
public class StoreUIImage : MonoBehaviour {

    public Sprite UnvailableItem;
    public Sprite AvailableItem;
    public Image ScrolledImage;
    public Text PlayerGold;
    public int SalePrice;
    // Use this for initialization

    private void ShowPlayerHaveGold()
    {
        PlayerGold.text = InputManager.Instance.ReadPlayerGold().ToString();
    }
    private void Start()
    {
        InputManager.Instance.DelegateGold += new ChangeGold(ChangeImage);
        InputManager.Instance.DelegateGold += new ChangeGold(ShowPlayerHaveGold);
        InputManager.Instance.DelegateGold();
    }
    public void ChangeImage()
    {
        if (InputManager.Instance.ReadPlayerGold() < SalePrice)
        {
            ScrolledImage.sprite = UnvailableItem;
        }
        else
        {
            ScrolledImage.sprite = AvailableItem;
        }
    }
}
