using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDecreaseHealth : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy")) {
            enemyHealth = GameObject.Find(other.gameObject.name).GetComponent("EnemyHealth") as EnemyHealth;
            enemyHealth.decreaseHealth(damage);
        }
    }
}
