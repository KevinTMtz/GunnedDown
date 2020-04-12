using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
        explosion = (GameObject) Resources.Load("Prefabs/Effects/EnemyDeath1", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.health <= 0) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
