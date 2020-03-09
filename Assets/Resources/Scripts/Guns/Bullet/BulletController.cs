using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Invoke("DestroyBullet", 1.5f);
    }

    // Destroy object after 1.5 seconds
    void DestroyBullet() {
        Destroy(gameObject);
    }
    
    // Detects if the collision is an object Foreground
    void OnCollisionEnter2D(Collision2D collision) {
       if (collision.gameObject.CompareTag("Foreground"))
            Destroy(gameObject);
    }
}
