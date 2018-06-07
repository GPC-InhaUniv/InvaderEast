using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreUIImage : MonoBehaviour {

    InputManager inputManager;
    public Sprite UnvailableItem;
    public Sprite AvailableItem;
    public Image ScrolledImage;
    
    public int SalePrice;
    // Use this for initialization

    private void Start()
    {
        

    }
    public void Testbtn2()
    {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.DelegateGold += new ChangeGold(ChangeImage);
        
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
