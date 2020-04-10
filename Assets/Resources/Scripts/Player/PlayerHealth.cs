using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    private int health;
    private bool isKill;

    [HideInInspector]
    public bool invinsible;

    private HealthBar healthBar;

    private GameObject blood1;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        isKill = false;

        healthBar = GameObject.Find("HealthBar").GetComponent("HealthBar") as HealthBar;
        healthBar.SetMaxHealth(health);

        blood1 = (GameObject) Resources.Load("Prefabs/Effects/BloodEffect1", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {   
        if (health == 0 && !isKill) {
            Debug.Log("You died!!!");
            isKill = true;
        }
    }

    public void decreaseHealth(int damage) {
        if (!invinsible)
            if (health - damage < 0) {
                health = 0;
            } else {
                health -= damage;
            }

        healthBar.SetHealth(health);
        GameObject blood = Instantiate(blood1, transform.position, transform.rotation);
        blood.transform.SetParent(transform);
        SoundManager.PlaySound("Hurt");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
            decreaseHealth(5);
    }
}
