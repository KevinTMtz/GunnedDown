using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMarine : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sprite;

    private ActivateForceShield forceField;
    // private ActivateTurret turret;
    // private ActivateBomb bomb;
    // private ActivateRadialAttack radialAtk;
    
    void Start()
    {
        Time.timeScale = 0;
        player = GameObject.Find("Player");
        sprite = player.GetComponent<SpriteRenderer>();
    }

    public void SelectKevin() {
        forceField = player.GetComponent<ActivateForceShield>();
        forceField.enabled = true;
        sprite.color = new Color(255f/255f, 97f/255f, 193f/255f);
        Cursor.visible = false;
        Time.timeScale = 1;
        SoundManager.PlaySound("MenuSound");
    }

    public void SelectSebas() {
        forceField = player.GetComponent<ActivateForceShield>();
        forceField.enabled = true;
        sprite.color = new Color(232f/255f, 255f/255f, 100f/255f);
        Cursor.visible = false;
        Time.timeScale = 1;
        SoundManager.PlaySound("MenuSound");
    }
    
    public void SelectMario() {
        forceField = player.GetComponent<ActivateForceShield>();
        forceField.enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1;
        SoundManager.PlaySound("MenuSound");
    }

    public void SelectEfren() {
        forceField = player.GetComponent<ActivateForceShield>();
        forceField.enabled = true;
        sprite.color = new Color(255f/255f, 118f/255f, 93f/255f);
        Cursor.visible = false;
        Time.timeScale = 1;
        SoundManager.PlaySound("MenuSound");
    }
}
