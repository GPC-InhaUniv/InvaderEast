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

    Rigidbody rigidbody;

    [SerializeField]
    GameObject[] itemModel;

    private void OnEnable()
    {
        SetItemInfo();
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * -speed;
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

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            GameMediator.Instance.PlaySound(SoundType.GetItem);
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
    private void OnDisable()
    {
       
    }

    private void OnDestroy()
    {
        StageManager.Instance.restart -= new Restart(ReturnPool);
    }
}
