using UnityEngine;

/// <summary>
/// Character를 상속받는다.
/// enum은 다른 클래스에서 사용하기 편하도록
/// 클래스 밖으로 빼놓았음.
/// Move는 재정의하여 Enemy에 맞도록
/// 내용을 채워넣었음.
/// </summary>
public class Enemy : Character
{
    [SerializeField]
    protected Direction direction;

    protected int giveScore;
    protected int giveMaxGold;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    void Died()
    {
        StageManager.Instance.RemoveEnemy(this);
    }

    public override void Attack()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public void Pattern()
    {

    }
}
