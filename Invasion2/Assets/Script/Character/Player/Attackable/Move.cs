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
    }

    private void OnTriggerEnter(Collider other)
    {

        if (tag == "PlayerBullet")
        {
            PoolManager.Instance.PutPlayerBulletObject(gameObject);
        }

        else if (tag != "Enemy")
        {
            PoolManager.Instance.PutEnemyBulletObject(gameObject);
        }

    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
        {
            if (tag == "PlayerBullet")
            {
                PoolManager.Instance.PutPlayerBulletObject(gameObject);
            }

            else
            {
                PoolManager.Instance.PutEnemyBulletObject(gameObject);
            }
        }
    }*/
}
