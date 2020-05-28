using UnityEngine;

public class SongPlayer : MonoBehaviour {
    public string mainTheme;
    
    void Start() {
        SoundManager.instance.Play(mainTheme);
    }
}
