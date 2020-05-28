using UnityEngine;

public class Boss : MonoBehaviour {
    public void PlaySound(string sound) {
        switch (sound) {
            case "DragonRoar":
                SoundManager.PlaySound("DragonRoar");
                break;
            case "DragonWings":
                SoundManager.PlaySound("DragonWings");
                break;
            case "Fireball":
                SoundManager.PlaySound("Fireball");
                break;
            case "Blitz":
                SoundManager.PlaySound("Blitz");
                break;
            case "Burst":
                SoundManager.PlaySound("Burst");
                break;
            case "DragonGrowl":
                SoundManager.PlaySound("DragonGrowl");
                break;
        }
    }

    public void AutoDestoy() {
        Destroy(gameObject);
    }
}
