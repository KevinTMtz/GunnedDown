using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
    private PlayerHealth playerHealth;
    public int damage;
    private GameObject explosion;
    
    void Start() {
        Destroy(gameObject, 4f);
        playerHealth = FindObjectOfType<PlayerHealth>();
        explosion = Resources.Load<GameObject>("Prefabs/Effects/BulletExplosionEffect1");
    }

    // Detects if the collision is an object Foreground or player
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            playerHealth.decreaseHealth(damage);
        
        if (!other.CompareTag("Enemy") &&
            !other.CompareTag("Bullet") &&
            !other.CompareTag("Boss") &&
            !other.CompareTag("Ignore") &&
            !other.CompareTag("Hydra") &&
            !other.CompareTag("Hole") &&
            !other.CompareTag("EnemyBullet")) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
