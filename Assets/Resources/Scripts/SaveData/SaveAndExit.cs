using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        SaveSystem.SaveGameData();
        Cursor.visible = true;
        ReturnToMenu();
    }

    public void ReturnToMenu() {
        PlayMenuSound();
        FindObjectOfType<SoundManager>().StopAllSongs();
        // TODO: Change later
        ItemsInventory.itemsInInventory.Clear();
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayMenuSound() {
        SoundManager.PlaySound("MenuSound");
    }
}
