﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGUI : MonoBehaviour
{
    private bool pauseMenuActive;
    private bool inventoryMenuActive;
    public GameObject pauseMenuBackground;
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public GameObject dialogueMenu;

    private Scene activeScene;

    private DialogueManager dialogueManager;
    
    void Start() {
        Time.timeScale = 1;
        pauseMenuActive = false;
        inventoryMenuActive = false;
        activeScene = SceneManager.GetActiveScene();

        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        bool dialogueCheck = dialogueManager.DialoguePanelIsActive;

        if (Input.GetKeyDown(KeyCode.Escape) && !inventoryMenuActive && !dialogueCheck)
            ShowPauseMenu();

        if (Input.GetKeyDown(KeyCode.E) && !pauseMenuActive && !dialogueCheck)
            ShowInventory();
    }

    public void ShowPauseMenu() {
        PlayMenuSound();
        
        if (!pauseMenuActive) {
            pauseMenuActive = true;
            pauseMenuBackground.SetActive(pauseMenuActive);
            pauseMenu.SetActive(pauseMenuActive);
            Cursor.visible = true;
            Time.timeScale = 0;
        } else {
            pauseMenuActive = false;
            pauseMenuBackground.SetActive(pauseMenuActive);
            pauseMenu.SetActive(pauseMenuActive);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void ShowInventory() {
        PlayMenuSound();
        
        if (!inventoryMenuActive) {
            inventoryMenuActive = true;
            pauseMenuBackground.SetActive(inventoryMenuActive);
            inventoryMenu.SetActive(inventoryMenuActive);
            Cursor.visible = true;
            Time.timeScale = 0;
        } else {
            inventoryMenuActive = false;
            pauseMenuBackground.SetActive(inventoryMenuActive);
            inventoryMenu.SetActive(inventoryMenuActive);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void Restart() {
        PlayMenuSound();
        FindObjectOfType<SoundManager>().StopAllSongs();
        // TODO: Change later
        ItemsInventory.itemsInInventory.Clear();
        SceneManager.LoadScene(activeScene.name);
    }

    public void Continue() {
        ShowPauseMenu();
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

    public GameObject DialoguePanel {
        get { return dialogueMenu; }
    }
}
