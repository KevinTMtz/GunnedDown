using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    private int health;
    private bool isKill;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        isKill = false;
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
        if (health - damage < 0) {
            health = 0;
        } else {
            health -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
            decreaseHealth(5);
    }
}
