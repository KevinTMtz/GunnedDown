using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health;
    
    public void decreaseHealth(int damage) {
        health -= damage;
    }
}
