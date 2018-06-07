using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

    GameMediator gameMediator;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }

    public void PlayerMove(Vector3 direction)
    {
        gameMediator.PlayerMove(direction);
    }

    public void ChangeScene(SceneState state)
    {
        gameMediator.ChangeScene(state);
    }

    public int ReadPlayerGold()
    {
        return gameMediator.ReadPlayerGold();
    }

    public int ReadPlayerMaxScore()
    {
        return gameMediator.ReadPlayerMaxScore();
    }

    public void BuyItem(Item item)
    {
        gameMediator.BuyItem(item);
       
    }

}
