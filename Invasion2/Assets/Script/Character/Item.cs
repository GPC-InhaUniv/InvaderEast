using UnityEngine;
/// <summary>
/// 담당자 : 김정수
/// 
/// 아이템 오브젝트에 장착될 간단한 정보를 가진 클래스
/// Gold와 Score 아이템은 생성시에 1 ~ 몬스터가 줄수 있는 최대 값사이의 랜덤값이 넣어진다.
/// </summary>

public class Item : MonoBehaviour
{
    ItemType itemType;
    int gold;
    int score;

    [SerializeField]
    float speed;

    Rigidbody rigidbodyComponent;

    [SerializeField]
    GameObject[] itemModel;

    private void OnEnable()
    {
        SetItemInfo();
        ChangeItemImage(itemType);
    }

    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.velocity = transform.forward * -speed;
        StageManager.Instance.restart += new Restart(ReturnPool);

    }

    public void ReturnPool()
    {
        PoolManager.Instance.PutItemObject(gameObject);
    }

    private void SetItemInfo()
    {
        itemType = (ItemType)Random.Range(0, 4);
        if (itemType >= (ItemType)2)
        {
            switch (itemType)
            {
                case ItemType.GoldItem:
                    gold = Random.Range(1, 10);
                    break;
                case ItemType.ScoreItem:
                    score = Random.Range(10, 50);
                    break;
            }
        }    
    }

    private void ChangeItemImage(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.PowerItem:
                itemModel[0].SetActive(true);
                itemModel[1].SetActive(false);
                itemModel[2].SetActive(false);
                itemModel[3].SetActive(false);
                break;
            case ItemType.LifeItem:

                itemModel[0].SetActive(false);
                itemModel[1].SetActive(false);
                itemModel[2].SetActive(true);
                itemModel[3].SetActive(false);
                break;
            case ItemType.GoldItem:
                itemModel[0].SetActive(false);
                itemModel[1].SetActive(false);
                itemModel[2].SetActive(false);
                itemModel[3].SetActive(true);
                break;
            case ItemType.ScoreItem:
                itemModel[0].SetActive(false);
                itemModel[1].SetActive(true);
                itemModel[2].SetActive(false);
                itemModel[3].SetActive(false);
                break;
            default:
                break;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            GameMediator.Instance.PlaySound(SoundType.UseItem);
            switch (itemType)
            {
                case ItemType.GoldItem:
                    ItemManager.Instance.GetItem(itemType, gold);

                    break;
                case ItemType.ScoreItem:
                    ItemManager.Instance.GetItem(itemType, score);

                    break;
                default:
                    ItemManager.Instance.GetItem(itemType);
                    break;
            }
            PoolManager.Instance.PutItemObject(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
        {
            PoolManager.Instance.PutItemObject(gameObject);
        }
    }

    private void OnDestroy()
    {
        StageManager.Instance.restart -= new Restart(ReturnPool);
    }
}
