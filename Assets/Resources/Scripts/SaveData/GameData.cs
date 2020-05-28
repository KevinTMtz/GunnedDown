[System.Serializable]
public class GameData {
    public int level;

    public GameData () {
        level = SaveSystem.ActiveLevelForSaving;
    }
}
