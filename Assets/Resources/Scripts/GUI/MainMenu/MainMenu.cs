using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
    }

    public void PlayTutorial() {
        PlayMenuSound();
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayLevel1() {
        PlayMenuSound();
        SceneManager.LoadScene("Level1");
    }
    
    public void PlayLevel2() {
        PlayMenuSound();
        //SceneManager.LoadScene("Level2");
        Debug.LogWarning("Scene for Level 2 does not exist");
    }

    public void PlayLevel3() {
        PlayMenuSound();
        //SceneManager.LoadScene("Level3");
        Debug.LogWarning("Scene for Level 3 does not exist");
    }

    public void QuitGame() {
        PlayMenuSound();
        Application.Quit();
    }

    public void PlayMenuSound() {
        SoundManager.PlaySound("MenuSound");
    }
}
