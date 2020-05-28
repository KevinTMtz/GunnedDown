using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndExit : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        SaveSystem.SaveGameData();
        Cursor.visible = true;
        ReturnToMenu();
    }

    public void ReturnToMenu() {
        PlayMenuSound();
        FindObjectOfType<SoundManager>().StopAllSongs();
        ItemsInventory.itemsInInventory.Clear();
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayMenuSound() {
        SoundManager.PlaySound("MenuSound");
    }
}
