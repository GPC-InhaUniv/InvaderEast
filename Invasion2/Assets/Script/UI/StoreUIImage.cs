using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreUIImage : MonoBehaviour {

    InputManager inputManager;
    public Sprite UnvailableItem;
    public Sprite AvailableItem;
    public Image PowerScrolled;
    public Image LifeScrolled;
    public Image MagnaticScrolled;
    public Image PowerRegenScrolled;
    public int SalePrice;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeImage()
    {
        if (inputManager.ReadPlayerGold() < SalePrice)
        {
        //    ScrolledImage.sprite = UnvailableItem;
        }
        else
        {
        //    ScrolledImage.sprite = AvailableItem;
        }
    }
}
