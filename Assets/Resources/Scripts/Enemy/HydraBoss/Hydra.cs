using UnityEngine;

public class Hydra : MonoBehaviour {
    public Transform[] targets;
    public int lastTarget;

    public void PlaySound(string sound) {
        switch (sound) {
            case "HydraLament":
                SoundManager.PlaySound("HydraLament");
                break;

            case "HydraDig":
                SoundManager.PlaySound("HydraDig");
                break;

            case "HydraBullet":
                SoundManager.PlaySound("HydraBullet");
                break;
        }
    }

    public void AutoDestoy() {
        Destroy(gameObject);
    }
}
