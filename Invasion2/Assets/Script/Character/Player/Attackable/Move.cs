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
}
