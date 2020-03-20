﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
    private PlayerHealth playerHealth;
    public int damage;
    private GameObject explosion;
    
    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 4f);
        
        playerHealth = GameObject.Find("Player").GetComponent("PlayerHealth") as PlayerHealth;
        
        explosion = (GameObject) Resources.Load("Prefabs/Effects/BulletExplosionEffect1", typeof(GameObject));
    }

    // Detects if the collision is an object Foreground or player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
            playerHealth.decreaseHealth(damage);
        
        if (!other.tag.Equals("Enemy") && !other.tag.Equals("Bullet")) {
            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);

            SoundManager.PlaySound("Explosion");
        }
    }
}
