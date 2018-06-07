using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUICtrl : MonoBehaviour {
    InputManager inputManager = InputManager.Instance;
    [SerializeField]
    ScrollRect ScrollPanel;

    public Sprite UnvailableItem;
    public Sprite AvailableItem;
    public Text ShowPlayerHaveGold;

    private void Start()
    {
        ShowPlayerHaveGold.text = GameDataManager.Instance.Gold.ToString();
    }

    public void ChangePanel()
    {

    }


}
