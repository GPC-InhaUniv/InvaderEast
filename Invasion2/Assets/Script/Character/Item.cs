using UnityEngine;

public enum ItemType
{
    PowerItem,
    LifeItem,
    GoldItem,
    ScoreItem,
    MagnaticItem,
    PowerRegenItem,
}

public class Item : MonoBehaviour {
    public ItemType ItemType;
    public int Gold;
    public int Score;
}
