using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public GameObject explosion;

    private EnemyHealth enemyHealth;
    public int damage;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) {
            enemyHealth = other.gameObject.GetComponent("EnemyHealth") as EnemyHealth;
            enemyHealth.decreaseHealth(damage);
        } else if (other.tag.Equals("Boss")) {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damage);
        } else if (other.tag.Equals("Hydra")) {
            HydraHealth bossHealth = other.GetComponent<HydraHealth>();
            bossHealth.TakeDamage(damage);
        }
    }

    public void FreezeMovement() {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
