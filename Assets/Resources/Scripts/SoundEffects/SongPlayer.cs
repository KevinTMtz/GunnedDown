using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public string mainTheme;
    
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Play(mainTheme);
    }
}
