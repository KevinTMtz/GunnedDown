using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth: MonoBehaviour
{
    public int health;
    private bool invulnerable;
    public Animator animator;
    private bool roar1, roar2;
    private int originalHealth;

    // Start is called before the first frame update
    void Start()
    {
        originalHealth = health;
        invulnerable = false;
        roar1 = true; 
        roar2 = true;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (invulnerable)
        {
            //Debug.Log("The enemy is invulnerable");
            return;
        }
        else
        {
            health =health-damage;
        }

        if (health <= 0)
        {
            //Die aniamtion
            animator.SetTrigger("Death");
        }
        else if (health <= originalHealth*.2f)
        {
            if (roar2)
            {
                animator.SetTrigger("Roar");
                roar2 = false;
            }
            //Burst attack
            animator.SetBool("Bursting", true);
            animator.SetBool("Fireballing", false);
            animator.SetBool("Blitzing", false);
            
        }
        else if (health <= originalHealth*0.6f)
        {
            if (roar1)
            {
                animator.SetTrigger("Roar");
                roar1 = false;
            }
            //Blitz attack
            animator.SetBool("Blitzing", true);
            animator.SetBool("Bursting", false);
            animator.SetBool("Fireballing", false);
        }
        else
        {
            //Fireball attack
            animator.SetBool("Fireballing", true);
            animator.SetBool("Bursting", false);
            animator.SetBool("Blitzing", false);
        }
    }
    public void ActivateInvulnerability()
    {
        invulnerable = true;
        //Debug.Log("Activating invulnerability");
    }
    public void DeactivateInvulnerability()
    {
        invulnerable = false;
        //Debug.Log("Deactivating invulnerability");
    }
}
