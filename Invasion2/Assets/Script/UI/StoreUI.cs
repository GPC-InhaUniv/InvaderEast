using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : MonoBehaviour {

    public Canvas Store;
   
    // Use this for initialization

    private void Start()
    {
      
        Store = GameObject.FindGameObjectWithTag("StoreUI").GetComponent<Canvas>();
       
    }
   
    public void OnExitButton()
    {
        InputManager.Instance.ChangeScene(SceneState.CharacterSelect);
    }
}
