using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    ///forward 에서 right로 수정 
    /// </summary>
    public float speed;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.right * speed;

    }
}
