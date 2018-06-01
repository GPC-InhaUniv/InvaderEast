using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;
/// <summary>
/// 게임 데이터 저장시 
/// </summary>
public class SaveAndLoader : MonoBehaviour
{
    [Serializable]
    private class GameData
    {
        public int Gold;
        public int MaxScore;
        public string filePath;
        public GameData()
        {
            filePath = Application.dataPath + "/GameData.bin";
        }
    }
    private static GameData Data = new GameData();
    public static void SaveData()
    {
        Data.Gold = GameDataManager.Instance.Gold;
        Data.MaxScore = GameDataManager.Instance.MaxScore;
        Debug.Log("골드: " + Data.Gold);
        Debug.Log("최대 스코어 : " + Data.MaxScore);
        Debug.Log("데이터 세이브");
        BinarySeriallize(Data);
    }
    public static void LoadData()
    {
        BinaryDeserialize();
        Debug.Log("데이터 로드");
        GameDataManager.Instance.Gold = Data.Gold;
        GameDataManager.Instance.MaxScore = Data.MaxScore;
        Debug.Log("소지 골드: " + Data.Gold);
        Debug.Log("최대 스코어: " + Data.MaxScore);
    }
    private static void BinarySeriallize(GameData data)
    {
        BinaryFormatter formattere = new BinaryFormatter();
        using (FileStream stream = new FileStream(data.filePath, FileMode.Create))
            formattere.Serialize(stream, data);
    }
    private static void BinaryDeserialize()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(Data.filePath, FileMode.Open))
            Data = (GameData)formatter.Deserialize(stream);
    }

}
