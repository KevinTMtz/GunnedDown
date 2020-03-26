using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFireTrap : MonoBehaviour
{
    private Transform childLight;

    private Animator animator;

    private bool ableToDamage;
    private bool onCollision;

    private PlayerHealth playerHealth;
    
    public float waitTime;
    public float durationTime;
    public int damage;
    
    // Start is called before the first frame update
    void Start() {
        playerHealth = GameObject.Find("Player").GetComponent("PlayerHealth") as PlayerHealth;
        
        animator = GetComponent<Animator>();
        childLight = transform.GetChild(0);

        ableToDamage = true;
    }

    void Update() {
        if (ableToDamage && onCollision) { 
            StartCoroutine(activateDamageBox());
            ableToDamage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag.Equals("Player"))
            onCollision = true;
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.tag.Equals("Player"))
            onCollision = false;
    }

    //void OnTriggerStay2D(Collider2D col) {}

    IEnumerator activateDamageBox() {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("Working", true);
        childLight.gameObject.SetActive(true);

        SoundManager.PlaySound("FireShot");

        if (onCollision) 
            playerHealth.decreaseHealth(damage);

        yield return new WaitForSeconds(durationTime);
        animator.SetBool("Working", false);
        childLight.gameObject.SetActive(false);
        ableToDamage = true;
    }
}
