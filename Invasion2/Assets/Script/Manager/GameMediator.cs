using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMediator : MonoBehaviour {

   public GameDataManager gameDatamanager;
    ItemManager itemMangager;
    SceneController sceneController;
    StageManager stageManager;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        gameDatamanager = GameDataManager.Instance;
        
        itemMangager = ItemManager.Instance;
        stageManager = StageManager.Instance;
        sceneController = SceneController.Instance;
        
	}
	
    void LoadData()
    {

    }
	
}
