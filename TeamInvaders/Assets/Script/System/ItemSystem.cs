using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    Power,
    Life,
    Magnatic,
    PowerRegen,
}

public class ItemSystem : MonoBehaviour {
    public float PowerItemCount;
    public float LifeItemCount;
    public bool MagnaticItem;
    public bool PowerRegenItem;


    public void OnGetItem(Item item)
    {
        switch (item)
        {
            case Item.Power:
                break;
            case Item.Life:
                break;
            default:
                break;
        }
    }


}
