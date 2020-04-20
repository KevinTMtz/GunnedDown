using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveObjects : MonoBehaviour
{
    private Animator animator;
    private int health;
    public int SetHealth;

    public string soundName;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = SetHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            DestroyObject();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Bullet")) {
            health -= other.gameObject.GetComponent<BulletController>().Damage;
            HitObject();
        }
    }

    void HitObject() {
        animator.SetTrigger("Hit");
    }

    void DestroyObject() {
        animator.SetBool("Explode", true);
        SoundManager.PlaySound(soundName);
        Destroy(this);
    }
}
