using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guaidance : MonoBehaviour, ISubAttackable
{
    new Rigidbody rigidbody;
    [SerializeField]
    GameObject homingMissile;
    [SerializeField]
    Transform spawnPos;
    [SerializeField]
    protected Transform target;
    float angle;
    [SerializeField]
    protected float rotateSpeed;
    [SerializeField]
    protected float moveSpeed;
    protected Vector3 chasing;
    int power;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        homingMissile = Resources.Load("HomingMissile",typeof(GameObject)) as GameObject;
        spawnPos = GameObject.FindWithTag("SubFirePos").GetComponent<Transform>();
        target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        HomingMove();
    }
    public void Attack(int power)
    {
        this.power = power;
        Debug.Log("호밍 미사일 : " + homingMissile);
        Debug.Log("스폰 좌표 : " + spawnPos);
        if (power == 40)
        {
            Instantiate(homingMissile, spawnPos.transform.position, Quaternion.identity);
        }
    }

    void HomingMove()
    {
        if(target)
        {
            chasing = target.transform.position - rigidbody.transform.position;
        }
        else
        {
            LostTarget();
        }
        Quaternion targetRotate = Quaternion.LookRotation(chasing);
        Quaternion SmoothRotate = Quaternion.Slerp(rigidbody.transform.rotation, targetRotate, rotateSpeed * Time.deltaTime);
        rigidbody.transform.rotation = SmoothRotate;
        rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }

    void LostTarget()
    {
        rigidbody.velocity = transform.forward * moveSpeed;
    }
}
