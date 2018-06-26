using UnityEngine;

/// <summary>
/// 담당자 : 이재환
/// -----------------------
/// Move에 관련한 스크립트
/// -----------------------
/// </summary>

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rigidbodyComponent;
    Transform thisTransform;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        thisTransform = gameObject.transform;
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = transform.forward * speed;
    }

    void Start()
    {
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(ReturnPool);
        transform.position = thisTransform.transform.position;
        transform.rotation = thisTransform.transform.rotation;
    }

    public void ReturnPool()
    {
        if (tag == "PlayerBullet")
        {
         
            GameMediator.Instance.PutPlayerBullet(gameObject);
        }

        if (tag == "EnemyBullet")
        {
         
            GameMediator.Instance.PutEnemyBullet(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (tag == "PlayerBullet" && other.tag != "Boundary")
        {
         
            GameMediator.Instance.PutPlayerBullet(gameObject);
        }

        if (tag == "EnemyBullet" && other.tag != "Boundary")
        {
            
            GameMediator.Instance.PutEnemyBullet(gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            if (tag == "PlayerBullet")
            {
               
                GameMediator.Instance.PutPlayerBullet(gameObject);
            }

            if (tag == "EnemyBullet")
            {
              
                GameMediator.Instance.PutEnemyBullet(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        GameMediator.Instance.DoGameOver -= new GameMediator.DoGameOverDelegate(ReturnPool);
    }
}
