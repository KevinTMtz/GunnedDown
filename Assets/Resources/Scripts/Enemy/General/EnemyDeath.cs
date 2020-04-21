using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    
    private EnemyHealth enemyHealth;

    private GameObject explosion;

    public bool deathFromAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
        explosion = (GameObject) Resources.Load("Prefabs/Effects/EnemyDeath1", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.health <= 0 && !deathFromAnimator) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (enemyHealth.health <= 0 && deathFromAnimator) {
            animator.SetBool("Death", true);
        }
    }

    void DestroyEnemy() {
        Destroy(gameObject);
    }
}
