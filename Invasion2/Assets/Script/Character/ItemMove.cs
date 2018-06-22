using UnityEngine;

public class ItemMove : MonoBehaviour {

    [SerializeField]
    float speed;

    Rigidbody rigidbody;
    
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
