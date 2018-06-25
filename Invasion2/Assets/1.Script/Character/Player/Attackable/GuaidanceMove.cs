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
    [SerializeField, Range(0,180)]
    float rotateSpeed;
    [SerializeField, Range(0,50)]
    float moveSpeed = 10.0f;

    private void OnEnable()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length>0)
        {
            FindTarget();
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length > 0)
        {
            FindTarget();
        }
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(ReturnPool);
        subAttackCtrl = FindObjectOfType<SubAttackCtrl>();
    }

    private void FixedUpdate()
    {
        HomingMove();
    }

    void HomingMove()
    {
        if (enemys.Length == 0)
        {
            LostTarget();
            return;
        }

        if (target.activeSelf == true)
        {
            chasing = target.transform.position - rigidbody.transform.position;
            chaingTarget = Quaternion.LookRotation(chasing);
            Quaternion SmoothRotate = Quaternion.Slerp(rigidbody.transform.rotation, chaingTarget, rotateSpeed * Time.deltaTime);
            rigidbody.transform.rotation = SmoothRotate;
            rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        }
        else if (target.activeSelf == false)
        {
            LostTarget();
        }

    }

    void LostTarget()
    {
        //rigidbody.velocity = transform.forward * moveSpeed;
        rigidbody.transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
    }

    GameObject FindTarget()
    {
        distance = Vector3.Distance(transform.position, enemys[0].transform.position);
        //Debug.Log("비교할 Enemy 위치 : " + distance);

        //Debug.Log("거리 : " + distance);
        foreach (GameObject enemyObject in enemys)
        {
            enemyDistance = Vector3.Distance(transform.position, enemyObject.transform.position);
            //Debug.Log("비교후 거리 : " + enemyDistance);
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
            rigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
            PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            if (tag == "HomingMissile")
            {
                rigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
                PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
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

    private void OnDisable()
    {
        
    }
    private void OnDestroy()
    {
        GameMediator.Instance.DoGameOver -= new GameMediator.DoGameOverDelegate(ReturnPool);
    }
}