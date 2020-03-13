﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Invoke("DestroyBullet", 3f);
    }

    // Destroy object after 1.5 seconds
    void DestroyBullet() {
        Destroy(gameObject);
    }
    
    // Detects if the collision is an object Foreground or enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) {
            Destroy(gameObject);
        }
    }
}
