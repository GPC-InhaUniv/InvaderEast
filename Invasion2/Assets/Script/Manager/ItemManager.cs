using UnityEngine;

public class ItemManager : Singleton<ItemManager> {

    protected ItemManager() { }
    public GameMediator gameMediator;
    public int PowerItemCount;
    public int LifeItemCount;
    public bool MagnaticItem;
    public bool PowerRegenItem;

    private void Start()
    {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
    }
}
