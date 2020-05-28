using UnityEngine;

public class BulletController : MonoBehaviour {
    private EnemyHealth enemyHealth;
    public int damage;
    private GameObject explosion;

    void Start() {
        Destroy(gameObject, 4f);
        explosion = Resources.Load<GameObject>("Prefabs/Effects/BulletExplosionEffect1");
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.decreaseHealth(damage);
        }
        
        if (other.CompareTag("Boss")) {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damage);
        }
        
        if (other.CompareTag("Hydra")) {
            HydraHealth bossHealth = other.GetComponent<HydraHealth>();
            bossHealth.TakeDamage(damage);
        }
        
        if (!other.CompareTag("Player") &&
            !other.CompareTag("PlayerChild") &&
            !other.CompareTag("Bullet") &&
            !other.CompareTag("Hole") &&
            !other.CompareTag("EnemyBullet") &&
            !other.CompareTag("Ignore")) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            SoundManager.PlaySound("Explosion");
        }
    }

    public int Damage {
        get { return damage; }
    }
}
