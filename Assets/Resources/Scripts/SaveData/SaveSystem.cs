using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    private static int activeLevel;
    private static int activeSaveSlot;

    public static void SaveGameData () {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + $"/GunnedDownData{activeSaveSlot}.save";

        GameData gameData = LoadGameData(activeSaveSlot);

        if (gameData == null || gameData.level < ActiveLevelForSaving) {
            FileStream stream = new FileStream(path, FileMode.Create);
            GameData data = new GameData();
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static GameData LoadGameData(int slotToLoad) {
        string path = Application.persistentDataPath + $"/GunnedDownData{slotToLoad}.save";
        if (!File.Exists(path))
            return null;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        GameData data = formatter.Deserialize(stream) as GameData;
        stream.Close();
        return data;
    }

    public static void DeleteFile (int slotToDelete) {
        File.Delete(Application.persistentDataPath + $"/GunnedDownData{slotToDelete}.save");
    }

    public static int ActiveLevelForSaving {
        get {
            switch (activeLevel) {
                case 0:
                    return 1;
                case 1:
                    return 2;
                case 2:
                case 3:
                    return 3;
                default:
                    return 0;
            }
        }
    }

    public static int ActiveLevel { 
        set { activeLevel = value; }
        get { return activeLevel; }
    }

    public static int ActiveSaveSlot {
        set { activeSaveSlot = value; }
        get { return activeSaveSlot; }
    }
}
