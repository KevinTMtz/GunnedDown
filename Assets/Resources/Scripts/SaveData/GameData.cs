using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public int level;

    public GameData () {
        if (SaveSystem.ActiveLevel == 0) {
            level = 1;
        } else if (SaveSystem.ActiveLevel == 1) {
            level = 2;
        } else if (SaveSystem.ActiveLevel == 2 || SaveSystem.ActiveLevel == 3) {
            level = 3;
        }
    }
}
