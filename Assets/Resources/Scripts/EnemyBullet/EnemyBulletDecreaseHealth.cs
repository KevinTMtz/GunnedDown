using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDecreaseHealth : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent("PlayerHealth") as PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
            playerHealth.decreaseHealth(damage);
    }
}
