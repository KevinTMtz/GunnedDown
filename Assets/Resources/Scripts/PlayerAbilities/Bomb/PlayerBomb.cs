using UnityEngine;

public class PlayerBomb : MonoBehaviour {
    public GameObject explosion;

    private EnemyHealth enemyHealth;
    public int damage;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            enemyHealth = other.gameObject.GetComponent< EnemyHealth>();
            enemyHealth.decreaseHealth(damage);
        } else if (other.CompareTag("Boss")) {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damage);
        } else if (other.CompareTag("Hydra")) {
            HydraHealth bossHealth = other.GetComponent<HydraHealth>();
            bossHealth.TakeDamage(damage);
        }
    }

    public void FreezeMovement() {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
