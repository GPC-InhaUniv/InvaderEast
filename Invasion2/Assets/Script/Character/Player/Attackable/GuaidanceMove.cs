using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuaidanceMove : MonoBehaviour
{
    [SerializeField]
    SubAttackCtrl subAttackCtrl;
    [SerializeField]
    GameObject[] enemys;
    Quaternion chaingTarget;
    Vector3 rightSpawnPos;
    Vector3 leftSpawnPos;
    [SerializeField]
    GameObject target;
    Vector3 chasing;


    new Rigidbody rigidbody;


    float angle;
    float enemyDistance;
    float distance;
    float minDistance;
    float rotateSpeed = 45.0f;
    float moveSpeed = 10.0f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemys.Length > 0)
        {
            if (enemys[0].activeInHierarchy)
            {
                FindTaget();
            }
        }
        StageManager.Instance.restart += new Restart(ReturnPool);
        subAttackCtrl = FindObjectOfType<SubAttackCtrl>();
    }

    private void FixedUpdate()
    {
        HomingMove();
    }

    void HomingMove()
    {
        if (target == null)
        {
            LostTarget();
        }
        else if (target.activeSelf == true)
        {
            chasing = target.transform.position - rigidbody.transform.position;
            chaingTarget = Quaternion.LookRotation(chasing);
            Quaternion SmoothRotate = Quaternion.Slerp(rigidbody.transform.rotation, chaingTarget, rotateSpeed * Time.deltaTime);
            rigidbody.transform.rotation = SmoothRotate;
            rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        }
        else if (target.activeSelf == false)
        {
            target = null;
            LostTarget();
        }

    }

    void LostTarget()
    {
        //rigidbody.velocity = transform.forward * moveSpeed;
        rigidbody.transform.rotation = rigidbody.transform.rotation;
        rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }

    GameObject FindTaget()
    {
        distance = Vector3.Distance(transform.position, enemys[0].transform.position);

        //Debug.Log("거리 : " + distance);
        foreach (GameObject enemyObject in enemys)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyObject.transform.position);
            //Debug.Log("거리 : " + enemyDistance);
            //Debug.Log("너는 누구냐 : " + enemyObject);
            if (enemyDistance <= distance)
            {
                target = enemyObject;
                distance = enemyDistance;
            }
        }

        return target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "HomingMissile" && other.tag != "Boundary")
        {
            PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
            Debug.Log("니가 누구냐 : " + subAttackCtrl.playerType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            if (tag == "HomingMissile")
            {
                PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
                Debug.Log("왜 널인가 : " + gameObject + "그것이 알고싶다 : " + subAttackCtrl.playerType);
            }
        }
    }

    public void ReturnPool()
    {
        if (tag == "HomingMissile")
        {
            PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
        }
    }
}