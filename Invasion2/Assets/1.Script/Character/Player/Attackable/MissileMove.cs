using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    [SerializeField,Range(1,150)]
    float moveSpeed;

    SubAttackCtrl subAttackCtrl;
    new Rigidbody rigidbody;

    private void Start()
    {
        subAttackCtrl = FindObjectOfType<SubAttackCtrl>();
        GameMediator.Instance.DoGameOver += new GameMediator.DoGameOverDelegate(ReturnPool);
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "StraightMissile" && other.tag != "Boundary")
        {
            PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
        {
            if(tag=="StraightMissile")
            {
                PoolManager.Instance.PutPlayerMissileObject(gameObject, subAttackCtrl.playerType);
            }
        }
    }

    void ReturnPool()
    {
        if(tag=="StraightMissile")
        {
            PoolManager.Instance.PutPlayerMissileObject(gameObject,subAttackCtrl.playerType);
        }
    }


    private void OnDestroy()
    {
        GameMediator.Instance.DoGameOver -= new GameMediator.DoGameOverDelegate(ReturnPool);
    }

}
