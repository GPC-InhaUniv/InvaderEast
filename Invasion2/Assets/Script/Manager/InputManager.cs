using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void ChangeGold();

public class InputManager : Singleton<InputManager>
{
   

    GameMediator gameMediator;
    public ChangeGold DelegateGold;
    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }

    public void PlayerMove(Vector3 direction)
    {
        gameMediator.PlayerMove(direction);
    }
    public void PlayerAttack(bool CheckedAttack)
    {
        gameMediator.PlayerAttack(CheckedAttack);
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
    public int ReadPlayerLife()
    {
        return gameMediator.ReadPlayerLife();
    }
    public int ReadCurrentScore()
    {
        return gameMediator.ReadCurrentScore();
    }
    public int ReadPlayerPower()
    {
        return gameMediator.ReadPlayerPower();
    }
    public void BuyItem(ItemType item, int SalePrice)
    {
        gameMediator.ChangeGold(-SalePrice);
        DelegateGold();
        gameMediator.BuyItem(item);
    }

    public void SellItem(ItemType item, int SalePrice)
    {
        gameMediator.ChangeGold(+SalePrice);
        DelegateGold();
        gameMediator.SellItem(item);
    }

    public void PlayerEquipMainWeapon(IMainAttackable MainWeapon)
    {
        gameMediator.PlayerEquipMainWeapon(MainWeapon);
    }
    public void PlayerEquipSubWeapon(ISubAttackable SubWeapon)
    {

    }

    public void PlayerChangeModel(PlayerType type)
    {
        gameMediator.ChangePlayerModel(type);
    }
   






}
