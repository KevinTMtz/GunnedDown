using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip sound1, sound2, sound3, sound4, sound5, sound6, sound7, sound8, sound9, sound10, sound11,sound12, sound13, sound14, spikes, fireShot;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Rename sounds and order them
        sound1 = Resources.Load<AudioClip>("Sounds/Inventory/cloth-inventory");
        sound2 = Resources.Load<AudioClip>("Sounds/Inventory/leather_inventory");
        sound3 = Resources.Load<AudioClip>("Sounds/Guns/shotgun-load");
        sound4 = Resources.Load<AudioClip>("Sounds/Guns/Shoot2");
        sound5 = Resources.Load<AudioClip>("Sounds/Movement/wood02");
        sound6 = Resources.Load<AudioClip>("Sounds/Explosions/explodemini");
        sound7 = Resources.Load<AudioClip>("Sounds/Menu/positive");
        sound8 = Resources.Load<AudioClip>("Sounds/Mix/metal_slide");
        
        // Dragon sounds
        sound9 = Resources.Load<AudioClip>("Sounds/Boss/Dragon_roar");
        sound10 = Resources.Load<AudioClip>("Sounds/Boss/DragonWings");
        sound11 = Resources.Load<AudioClip>("Sounds/Boss/fireball");
        sound12 = Resources.Load<AudioClip>("Sounds/Boss/Blitz");
        sound13 = Resources.Load<AudioClip>("Sounds/Boss/Burst");
        sound14 = Resources.Load<AudioClip>("Sounds/Boss/Dragon_growl");

        // Traps sounds
        spikes = Resources.Load<AudioClip>("Sounds/Traps/spikes");
        fireShot = Resources.Load<AudioClip>("Sounds/Traps/fireShot");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case"ClothInventory":
                audioSrc.PlayOneShot(sound1, 0.5f);
                break;
            case"LeatherInventory":
                audioSrc.PlayOneShot(sound2, 0.35f);
                break;
            case"ShotgunLoad":
                audioSrc.PlayOneShot(sound3, 0.35f);
                break;
            case"Shoot2":
                audioSrc.PlayOneShot(sound4, 0.20f);
                break;
            case"Steps":
                audioSrc.PlayOneShot(sound5, 0.5f);
                break;
            case"Explosion":
                audioSrc.PlayOneShot(sound6, 0.15f);
                break;
            case"MenuSound":
                audioSrc.PlayOneShot(sound7, 1f);
                break;
            case"MetalSlide":
                audioSrc.PlayOneShot(sound8, 1f);
                break;
            case "DragonRoar":
                audioSrc.PlayOneShot(sound9, 0.75f);
                break;
            case "DragonWings":
                audioSrc.PlayOneShot(sound10, 0.125f);
                break;
            case "Fireball":
                audioSrc.PlayOneShot(sound11, 0.75f);
                break;
            case "Blitz":
                audioSrc.PlayOneShot(sound12, 0.75f);
                break;
            case "Burst":
                audioSrc.PlayOneShot(sound13, 0.75f);
                break;
            case "DragonGrowl":
                audioSrc.PlayOneShot(sound14, 1.75f);
                break;
            case "Spikes":
                audioSrc.PlayOneShot(spikes, 0.35f);
                break;
            case "FireShot":
                audioSrc.PlayOneShot(fireShot, 0.35f);
                break;
        }
    }
}
