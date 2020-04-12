using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBehavior : MonoBehaviour
{
    private Animator animator;
    private EnemyHealth enemyHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.Find("EnemySprite").GetComponent<Animator>();
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.health <= 0) {
            animator.SetBool("IsDying", true);
        }
    }
}
