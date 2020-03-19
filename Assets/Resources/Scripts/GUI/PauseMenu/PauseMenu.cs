using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool pauseMenuActive;
    public GameObject pauseMenuBackground;
    public GameObject pauseMenu;

    private Scene activeScene;
    
    void Start() {
        Time.timeScale = 1;
        
        pauseMenuActive = false;
        
        activeScene = SceneManager.GetActiveScene();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    public void Pause() {
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

    public void Restart() {
        PlayMenuSound();
        SceneManager.LoadScene(activeScene.name);
    }

    public void Continue() {
        Pause();
    }

    public void ReturnToMenu() {
        PlayMenuSound();
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayMenuSound() {
        SoundManager.PlaySound("MenuSound");
    }
}
