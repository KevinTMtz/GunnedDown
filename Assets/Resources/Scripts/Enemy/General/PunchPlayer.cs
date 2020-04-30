using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPlayer : MonoBehaviour
{
    private Transform player;
    private PlayerHealth playerHealth;
    private Animator animator;
    private bool isAttacking;
    
    public bool hitAnimation;
    public int damage;
    public float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitAnimation)
            HitPlayerWithAnimation();
    }

    void HitPlayerWithAnimation() {
        if (Vector2.Distance(transform.position, player.position) < distance && !isAttacking) {
            isAttacking = true;
            animator.SetBool("Attacking", true);
        } else if (Vector2.Distance(transform.position, player.position) > distance && isAttacking) {
            isAttacking = false;
            animator.SetBool("Attacking", false);
        }
    }

    void HitPlayerWithOutAnimation() {
        if (Vector2.Distance(transform.position, player.position) < distance)
            HitPlayer();
    }

    void HitPlayer() {
        playerHealth.decreaseHealth(damage);
    }
}
