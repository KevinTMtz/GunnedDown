using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private EnemyHealth enemyHealth;
    public int damage;
    private GameObject explosion;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 4f);

        explosion = (GameObject) Resources.Load("Prefabs/Effects/BulletExplosionEffect1", typeof(GameObject));
    }
    
    // Detects if the collision is an object Foreground or enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) {
            enemyHealth = GameObject.Find(other.gameObject.name).GetComponent("EnemyHealth") as EnemyHealth;
            enemyHealth.decreaseHealth(damage);
        }
        
        if (other.tag.Equals("Boss")) {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damage);
        }
        if (other.tag.Equals("Hydra"))
        {
            HydraHealth bossHealth = other.GetComponent<HydraHealth>();
            bossHealth.TakeDamage(damage);
        }
        bool check = (!other.tag.Equals("Player") && !other.tag.Equals("PlayerChild") && !other.tag.Equals("Bullet") && !other.tag.Equals("Hole") && !other.tag.Equals("EnemyBullet") &&!other.tag.Equals("Ignore"));
        if (check) {
            Destroy(gameObject);

            Instantiate(explosion, transform.position, transform.rotation);

            SoundManager.PlaySound("Explosion");
        }
    }

    public int Damage {
        get { return damage; }
    }
}
