using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUI : MonoBehaviour {

    public Canvas Store;
    InputManager inputManager;
    // Use this for initialization

    private void Start()
    {
       inputManager= FindObjectOfType<InputManager>();
        Store = GameObject.FindGameObjectWithTag("StoreUI").GetComponent<Canvas>();
       
    }
   
    public void OnExitButton()
    {
        inputManager.ChangeScene(SceneState.CharacterSelect);
    }
}
