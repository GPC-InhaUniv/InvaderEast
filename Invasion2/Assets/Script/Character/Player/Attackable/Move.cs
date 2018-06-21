using UnityEngine;

/// <summary>
///
/// </summary>

public class Move : MonoBehaviour
{
    public float speed;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
        StageManager.Instance.restart += new Restart(ReturnPool);
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

        if(tag == "EnemyBullet" && other.tag != "Boundary")
        {
            PoolManager.Instance.PutEnemyBulletObject(gameObject);
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
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
}
