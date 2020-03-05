using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sound1;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        sound1 = Resources.Load<AudioClip>("Sounds/file_name");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case"asteroidEx":
                audioSrc.PlayOneShot(sound1, 1f);
                break;
        }
    }
}
