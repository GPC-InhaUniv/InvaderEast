using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreUIImage : MonoBehaviour {

    InputManager inputManager;
    public Sprite UnvailableItem;
    public Sprite AvailableItem;
    public Image ScrolledImage;
    public Text PlayerGold;
    public int SalePrice;
    // Use this for initialization

    private void ShowPlayerHaveGold()
    {
        PlayerGold.text = inputManager.ReadPlayerGold().ToString();
    }
    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.DelegateGold += new ChangeGold(ChangeImage);
        inputManager.DelegateGold += new ChangeGold(ShowPlayerHaveGold);
        try
        {
            inputManager.DelegateGold();
        }
        catch
        {
            inputManager = FindObjectOfType<InputManager>();
        }
    }
    public void ChangeImage()
    {
        
        if (inputManager.ReadPlayerGold() < SalePrice)
        {
            ScrolledImage.sprite = UnvailableItem;
        }
        else
        {
            ScrolledImage.sprite = AvailableItem;
        }
    }
}
