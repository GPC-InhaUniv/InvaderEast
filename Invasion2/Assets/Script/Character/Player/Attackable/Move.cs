using UnityEngine;

/// <summary>
/// 담당자 : 이재환
/// 
/// </summary>

public class Move : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rigidbody;
    Transform thisTransform;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        thisTransform = gameObject.transform;
    }


    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * speed;
    }

    void Start()
    {
        StageManager.Instance.restart += new Restart(ReturnPool);
        transform.position = thisTransform.transform.position;
        transform.rotation = thisTransform.transform.rotation;
    }

    public void ReturnPool()
    {
        if (tag == "PlayerBullet")
        {
            PoolManager.Instance.PutPlayerBulletObject(gameObject);
        }

        if (tag == "EnemyBullet")
        {
            PoolManager.Instance.PutEnemyBulletObject(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (tag == "PlayerBullet" && other.tag != "Boundary")
        {
            PoolManager.Instance.PutPlayerBulletObject(gameObject);
        }

        if (tag == "EnemyBullet" && other.tag != "Boundary")
        {
            PoolManager.Instance.PutEnemyBulletObject(gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            if (tag == "PlayerBullet")
            {
                PoolManager.Instance.PutPlayerBulletObject(gameObject);
            }

            if (tag == "EnemyBullet")
            {
                PoolManager.Instance.PutEnemyBulletObject(gameObject);
            }
        }
    }

    private void OnDisable()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
    }

    private void OnDestroy()
    {
        StageManager.Instance.restart -= new Restart(ReturnPool);
    }
}
