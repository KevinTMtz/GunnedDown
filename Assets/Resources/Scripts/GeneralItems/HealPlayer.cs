using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int heal;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Player")) {
            FindObjectOfType<PlayerHealth>().IncreaseHealth(heal);
            Destroy(gameObject);
        }
    }
}
