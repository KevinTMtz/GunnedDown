using UnityEngine;

public class HealPlayer : MonoBehaviour {
    public int heal;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            FindObjectOfType<PlayerHealth>().IncreaseHealth(heal);
            Destroy(gameObject);
        }
    }
}
