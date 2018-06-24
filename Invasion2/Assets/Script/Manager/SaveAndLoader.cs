using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;

/// <summary>
/// 담당자 : 김정수
/// 
/// 아래 GameData 클래스를 이용해 데이터를 직렬화하여 저장 및 불러오기를 한다.
/// </summary>

public class SaveAndLoader : Singleton<SaveAndLoader>
{

    [Serializable]
   public  class GameData
    {
        public int Gold;
        public int MaxScore;
        public string filePath= Application.dataPath + "/GameData.bin";
    }
    public  GameData gameData;
    
    private void Awake()
    {
        gameData = new GameData();
        gameData.filePath = Application.persistentDataPath + "/GameData.bin";
    }

    public void SaveData()
    {
        gameData.Gold = GameMediator.Instance.ReadPlayerGold();
        gameData.MaxScore = GameMediator.Instance.ReadPlayerMaxScore();
        BinarySerialize(gameData, gameData.filePath);
        Debug.Log("저장완료");
    }

    public void LoadData()
    {
        Debug.Log(gameData.filePath);
        BinaryDeserialize(gameData.filePath);
        Debug.Log("불러오기");
        Debug.Log("골드 : " + gameData.Gold);
        Debug.Log("최대 스코어 :" + gameData.MaxScore);
        GameDataManager.Instance.ChangeGold(gameData.Gold);
        GameDataManager.Instance.ChangeScore(gameData.MaxScore);
        GameDataManager.Instance.EndGame();
    }

    private void BinaryDeserialize(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            gameData = (GameData)formatter.Deserialize(stream);
        }   

        /*
FileStream stream = new FileStream(filePath, FileMode.Open);
gameData = (GameData)formatter.Deserialize(stream);
stream.Close();*/
    }

    private void BinarySerialize(GameData Data, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, gameData);
        }
        /*
            FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, gameData);
        stream.Close();*/
    }



}
/// <summary>
///                  [안드로이드 External]
///Application.persistentDataPath : /mnt/sdcard/Android/data/번들이름/files
///파일 읽기 쓰기 가능
///Application.dataPath : /data/app/번들이름-번호.apk
///Application.streamingAssetsPath : jar:file:///data/app/번들이름.apk!/assets 
///파일이 아닌 WWW로 읽기 가능
///                  [안드로이드 Internal]
///Application.persistentDataPath : /data/data/번들이름/files/
///파일 읽기 쓰기 가능
///Application.dataPath : /data/app/번들이름-번호.apk
///Application.streamingAssetsPath : jar:file:///data/app/번들이름.apk!/assets
///파일이 아닌 WWW로 읽기 가능
///
/// 
/// </summary>