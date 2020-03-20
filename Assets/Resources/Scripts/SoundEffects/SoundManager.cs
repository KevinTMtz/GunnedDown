using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sound1, sound2, sound3, sound4, sound5, sound6, sound7, sound8;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        sound1 = Resources.Load<AudioClip>("Sounds/Inventory/cloth-inventory");
        sound2 = Resources.Load<AudioClip>("Sounds/Inventory/leather_inventory");
        sound3 = Resources.Load<AudioClip>("Sounds/Guns/shotgun-load");
        sound4 = Resources.Load<AudioClip>("Sounds/Guns/Shoot2");
        sound5 = Resources.Load<AudioClip>("Sounds/Movement/wood02");
        sound6 = Resources.Load<AudioClip>("Sounds/Explosions/explodemini");
        sound7 = Resources.Load<AudioClip>("Sounds/Menu/positive");
        sound8 = Resources.Load<AudioClip>("Sounds/Mix/metal_slide");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case"ClothInventory":
                audioSrc.PlayOneShot(sound1, 0.5f);
                break;
            case"LeatherInventory":
                audioSrc.PlayOneShot(sound2, 0.5f);
                break;
            case"ShotgunLoad":
                audioSrc.PlayOneShot(sound3, 0.5f);
                break;
            case"Shoot2":
                audioSrc.PlayOneShot(sound4, 0.35f);
                break;
            case"Steps":
                audioSrc.PlayOneShot(sound5, 0.5f);
                break;
            case"Explosion":
                audioSrc.PlayOneShot(sound6, 0.20f);
                break;
            case"MenuSound":
                audioSrc.PlayOneShot(sound7, 1f);
                break;
            case"MetalSlide":
            audioSrc.PlayOneShot(sound8, 1f);
            break;
        }
    }
}
