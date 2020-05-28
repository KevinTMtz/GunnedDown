using UnityEngine;

[System.Serializable]

public class Dialogue {
    public string name;

    [TextArea(3,6)]
    public string[] sentences;
}
