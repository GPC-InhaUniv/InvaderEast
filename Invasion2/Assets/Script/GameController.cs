
using UnityEngine;

public class GameController : MonoBehaviour {

    GameMediator gameMediator;
	// Use this for initialization
	void Start () {
        gameMediator = GameObject.FindGameObjectWithTag("GameMediator").GetComponent<GameMediator>();
        gameMediator.SetFactory();
	}
	
	
}
